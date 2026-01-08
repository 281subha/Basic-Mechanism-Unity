using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    private Vector2 []dirArray;
    private Vector2 firstPos;
    public float speed = 5f;
    public bool isTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPos = transform.position;
    }

    void Update()
    {
        if (isTriggered)
        {

            SetDirection();
            Move();
        }
        // else
        // {
        //     StoreDirection();
        // }
            
        float xPos = Mathf.Clamp(transform.position.x, -8f, 8f);
        float yPos = Mathf.Clamp(transform.position.y, -5f, 5f);
        if(transform.position.x != xPos || transform.position.y != yPos)
        {
            // isTriggered = false;
            transform.position = firstPos;
        }
    }

    private void SetDirection()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector2.up;
        if(Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector2.down;
        if(Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector2.right;
        if(Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector2.left;
    }

    private void Move()
    {
        rb.linearVelocity = dir * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
        Debug.Log("Triggered");
        // if (other.gameObject)
        // {
        //     Debug.Log("Triggered");
        // }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
        Debug.Log("Exited Trigger");
    }
}
