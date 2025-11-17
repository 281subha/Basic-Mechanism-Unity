using System;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public GameObject target;
    private Vector3 mousePos;
    private Vector3 offset;
    private Vector3 resetPos;
    private bool isFinish;

    void Start()
    {
        resetPos = transform.position;
    }
    void Update()
    {
        if (!isFinish)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void OnMouseDown() 
    {
        offset = transform.position - mousePos;
    }
    private void OnMouseDrag()
    {
        transform.position = mousePos + offset;
    }
    private void OnMouseUp()
    {
        if(Math.Abs(transform.position.x - target.transform.position.x) < 0.5f && Math.Abs(transform.position.y - target.transform.position.y) < 0.5f)
        {
            transform.position = target.transform.position;
            isFinish = true;
        }
        else
        {
            transform.position = resetPos;
        }
    }
}
