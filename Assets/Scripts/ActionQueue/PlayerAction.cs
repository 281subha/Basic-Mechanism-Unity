using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    public float speed = 5f;
    public bool isTriggered = false;
    public bool isOuterInput = false;

    // **************This code is for changing color by clicking space button.********************

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isTriggered) ChangeColor();
            else isOuterInput = true;
        }
        if (isTriggered && isOuterInput)
        {
            ChangeColor();
            isOuterInput = false;
        }
    }
    private void ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private void Move()
    {
        
        if(Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector2.up; 
        if(Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector2.down; 
        if(Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector2.right; 
        if(Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector2.left; 

        rb.linearVelocity = dir * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
        Debug.Log("Triggered");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
        Debug.Log("Exited Trigger");
    }
}
