using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    [SerializeField]
    private Transform Btoxico;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public static bool lockedS;

    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!lockedS)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!lockedS)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - Btoxico.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - Btoxico.position.y) <= 0.5f)
        {
            this.gameObject.SetActive(false);
            Btoxico.gameObject.SetActive(false);
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

}
