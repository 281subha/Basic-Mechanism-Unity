using UnityEngine;

public class Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastMousePos;
    private Vector2 currentMousePos;
    private Vector2 delta;

    public float force = 5f;

    private bool isDragging;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            isDragging = true;
            rb.linearVelocity = Vector2.zero;
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            delta = lastMousePos - currentMousePos;

            rb.AddForce(delta * force, ForceMode2D.Impulse);
            isMoving = true;
        }
    }

    void FixedUpdate()
    {
        if (isMoving && rb.linearVelocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
            isMoving = false;
        }
    }
}


