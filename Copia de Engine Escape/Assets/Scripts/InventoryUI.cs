using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject draggableItemPrefab;
    public GameObject inventorySlotPrefab;
    public Transform inventorySlotContainer;

    private GameObject draggedItem;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i < inventorySlotContainer.childCount)
            {
                inventorySlotContainer.GetChild(i).GetComponentInChildren<Image>().sprite = inventory.items[i].itemSprite;
                Button button = inventorySlotContainer.GetChild(i).GetComponent<Button>();
                int itemIndex = i; // Guardar el índice del artículo en una variable local
                button.onClick.RemoveAllListeners(); // Eliminar todos los listeners previos
                button.onClick.AddListener(() => OnItemButtonClicked(itemIndex)); // Agregar un nuevo listener con el índice del artículo
            }
            else
            {
                GameObject newSlot = Instantiate(inventorySlotPrefab, inventorySlotContainer);
                newSlot.GetComponentInChildren<Image>().sprite = inventory.items[i].itemSprite;
                Button button = newSlot.GetComponent<Button>();
                int itemIndex = i; // Guardar el índice del artículo en una variable local
                button.onClick.AddListener(() => OnItemButtonClicked(itemIndex)); // Agregar un listener con el índice del artículo
            }
        }
    }

    public void OnItemButtonClicked(int itemIndex)
    {
        if (itemIndex >= 0 && itemIndex < inventory.items.Count)
        {
            inventory.UseItem(inventory.items[itemIndex]);
            StartDraggingItem(inventory.items[itemIndex]);
        }
    }

    private void StartDraggingItem(Item item)
    {
        draggedItem = Instantiate(draggableItemPrefab);
        draggedItem.name = "Dragged Item";
        SpriteRenderer spriteRenderer = draggedItem.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.itemSprite;
        spriteRenderer.sortingOrder = 1; // Asegurarse de que el objeto arrastrado esté en una capa superior

        // Comenzar a arrastrar el objeto
        StartCoroutine(DragItem());
    }

    private IEnumerator DragItem()
    {
        while (Input.GetMouseButton(0))
        {
            // Convertir la posición del cursor del mouse a coordenadas de mundo
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Ajustar la distancia en el eje Z para que el objeto se muestre correctamente en la cámara
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Actualizar la posición del objeto arrastrado
            draggedItem.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);

            // Esperar al siguiente fotograma
            yield return null;
        }

        // Destruir el objeto arrastrado cuando se suelta el botón del mouse
        Destroy(draggedItem);
    }
}
