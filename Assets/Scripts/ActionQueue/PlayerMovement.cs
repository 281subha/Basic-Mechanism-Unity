using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    private Vector2[] inputBuffer;
    private int writeIndex = 0;
    private int readIndex = 0;
    private Vector2 firstPos;
    public float speed = 5f;
    public bool isTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPos = transform.position;
        inputBuffer = new Vector2[20];
    }

    void Update()
    {
        if(SetAction() && writeIndex<inputBuffer.Length)
        {
            inputBuffer[writeIndex] = dir;
            writeIndex ++;
        }

        if (isTriggered && writeIndex>readIndex)
        {
            Move();
            // StartCoroutine (Move());
        }
            
        float xPos = Mathf.Clamp(transform.position.x, -8f, 8f);
        float yPos = Mathf.Clamp(transform.position.y, -5f, 5f);
        if(transform.position.x != xPos || transform.position.y != yPos)
        {
            // isTriggered = false;
            transform.position = firstPos;
        }
    }

    private bool SetAction()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {dir = Vector2.up; return true;}
        if(Input.GetKeyDown(KeyCode.DownArrow)) {dir = Vector2.down; return true;}
        if(Input.GetKeyDown(KeyCode.RightArrow)) {dir = Vector2.right; return true;}
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {dir = Vector2.left; return true;}

        return false;
    }

    private void Move()
    // private IEnumerator Move()
    {
        // yield return new WaitForSeconds(0.3f);
        rb.linearVelocity = inputBuffer[readIndex] * speed;
        readIndex ++;
        if(readIndex >= writeIndex)
        {
            readIndex = 0;
            writeIndex = 0;
        }
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
