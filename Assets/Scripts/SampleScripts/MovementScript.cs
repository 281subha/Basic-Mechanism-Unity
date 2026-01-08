using UnityEngine;

 
 
public class MovementScript : MonoBehaviour
{
    public enum DIRECTIONS
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
 
    private Rigidbody2D rb;
 
    private float moveSpeed = 10f;
 
    private DIRECTIONS _setDirections;
 
 
    void Start()
    {
        _setDirections = DIRECTIONS.NONE;
        rb = GetComponent<Rigidbody2D>();
        // left = rb.linearVelocity.
    }
 
    void Update()
    {
        SetDirections();
        GetInput();
    }
 
    void  SetDirections()
    {
        if(_setDirections == DIRECTIONS.UP)
        {
            rb.linearVelocity = Vector2.up * moveSpeed;
        }
        if(_setDirections == DIRECTIONS.DOWN)
        {
            rb.linearVelocity = Vector2.down * moveSpeed;
        }
        if(_setDirections == DIRECTIONS.LEFT)
        {
            rb.linearVelocity = Vector2.left *  moveSpeed;
        }
        if(_setDirections == DIRECTIONS.RIGHT)
        {
            rb.linearVelocity = Vector2.right * moveSpeed;
        }
        if(_setDirections == DIRECTIONS.NONE)
        {
            rb.linearVelocity = Vector2.zero;
        }
        // _setDirections = DIRECTIONS.NONE;
        // rb.linearVelocity = Vector2.zero;
    }
 
    void GetInput()
    {
        // if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        // {
        //     _setDirections = DIRECTIONS.NONE;
        // }
        if(Input.GetKeyDown(KeyCode.A))
        {
            _setDirections = DIRECTIONS.LEFT;
            Debug.Log("left");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            _setDirections = DIRECTIONS.RIGHT;
            Debug.Log("right");
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            _setDirections = DIRECTIONS.UP;
            Debug.Log("up");
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _setDirections = DIRECTIONS.DOWN;
            Debug.Log("down");
        }
    }
}