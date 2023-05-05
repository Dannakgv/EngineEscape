using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;

    private void OnMouseDown()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            item.itemGameObject = gameObject; // Agrega esta línea
            gameObject.SetActive(false); // Reemplaza Destroy(gameObject) por esta línea
            inventory.AddItem(item);
        }
    }
}
