using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Vector2 defaultPos;
    private Vector2 currentPos;
    public float speed;
    private Vector2 mousePos;

    // Drag Shoot *******************
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnMouseDrag()
    {
        transform.position = mousePos;
        currentPos = transform.position;
        moveDir = defaultPos - currentPos;
    }
    void OnMouseUp()
    {
        Move();
        Invoke(nameof(StopMoving), 5f);
    }

    // Tap shoot **************************
    // private void Start()
    // {
    //     rb = gameObject.GetComponent<Rigidbody2D>();
    //     moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    //     defaultPos = transform.position;
    // }
    // private void OnMouseDown()
    // {
    //     Move();
    //     Invoke("StopMoving", 5f);
    // }
    private void Move()
    {
        rb.linearVelocity = moveDir * speed;
    }
    private void StopMoving()
    {
        rb.linearVelocity = moveDir * 0;
        transform.position = defaultPos;
    }
}
