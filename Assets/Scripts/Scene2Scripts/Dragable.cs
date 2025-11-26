using System;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public GameObject target;
    private Vector2 mousePos;
    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        if(Math.Abs(transform.position.x - target.transform.position.x) < 1f && Math.Abs(transform.position.y - target.transform.position.y) < 1f)
        {
            transform.position = target.transform.position;
            gameObject.SetActive(false);
        }
    }
}
