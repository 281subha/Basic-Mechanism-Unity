using System.Collections;
using UnityEngine;

public class DecisionDelay : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    public float speed = 5f;
    private bool isMovable = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector2.up; 
        if(Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector2.down; 
        if(Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector2.right; 
        if(Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector2.left;

        if (dir != Vector2.zero && isMovable)
        {
            // StartCoroutine(Move());
            Invoke("Move", 1.5f);
            isMovable = false;
        }
    }
    // private IEnumerator Move()
    // {
    //     yield return new WaitForSeconds(1f);
    //     rb.linearVelocity = dir * speed;
    //     dir = Vector2.zero;
    // }

    private void Move()
    {
        rb.linearVelocity = dir * speed;
    }
    
}
