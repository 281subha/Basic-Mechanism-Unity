using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 movement;

    

    // private Enum goUp = KeyCode.UpArrow;
    // private Enum goDown = KeyCode.DownArrow;
    // private Enum goLeft = KeyCode.LeftArrow;
    // private Enum goRight = KeyCode.RightArrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // bool up = Input.GetKeyDown(KeyCode.UpArrow);
        // bool down = Input.GetKeyDown(KeyCode.DownArrow);
        // bool left = Input.GetKeyDown(KeyCode.LeftArrow);
        // bool right = Input.GetKeyDown(KeyCode.RightArrow);

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        movement = new Vector2(horizontalInput, verticalInput);
        rb.linearVelocity = movement*speed;
    }
}
