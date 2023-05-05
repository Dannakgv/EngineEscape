using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject levelCompletedPanel;
    public Button continueButton;
    public ScoreManager scoreManager;

    void Start()
    {
        continueButton.gameObject.SetActive(false);
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

void Update()
{
    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        // Comprueba si el raycast ha golpeado algún objeto
        if (hit.collider == null)
        {
            // Si no se ha golpeado ningún objeto, resta 10 puntos
            scoreManager.SubtractPoints(10);
        }
    }
}


    public void AddItem(Item item)
    {
        items.Add(item);

        scoreManager.AddPoints(100);

        if (items.Count == 7)
        {
            levelCompletedPanel.GetComponent<CanvasGroup>().alpha = 1;
            levelCompletedPanel.GetComponent<CanvasGroup>().interactable = true;
            levelCompletedPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            continueButton.gameObject.SetActive(true);
        }
    }

    public void UseItem(Item item)
    {
        // Implementa la lógica de uso del objeto aquí
    }



public void SubtractPointsWhenClickedOnWrongPlace()
{
    scoreManager.SubtractPoints(10); // Asume que tienes una referencia a ScoreManager en tu script Inventory
}

}
