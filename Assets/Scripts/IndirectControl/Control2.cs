using UnityEngine;

public class Control2 : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 dragStartPos;
    private Vector2 lastMousePos;
    private bool isDragging;

    [SerializeField] private float launchForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            rb.linearVelocity = Vector2.zero;

            dragStartPos = transform.position;
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Launch();
        }

        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 delta = mousePos - lastMousePos;

            transform.position += (Vector3)delta;
            lastMousePos = mousePos;
        }
    }

    void Launch()
    {
        Vector2 direction = dragStartPos - (Vector2)transform.position;
        rb.linearVelocity = direction * launchForce;
    }
}