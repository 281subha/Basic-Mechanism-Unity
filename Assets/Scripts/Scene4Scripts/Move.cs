using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    private Vector2 target;
    private Vector2 mousePos;
    private Vector2 rotateDir;
    private Vector2 startPoint;
    private Vector2 endPoint;
    public float speed = 0.6f;
    public float height = 2f;
    public float t;
    private float startTime;
    private bool stop = false;
    void Start()
    {
        startPoint = target1.position;
        endPoint = target2.position;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Settarget();
        rotateDir = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(rotateDir.y, rotateDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if(stop == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 3f * Time.deltaTime);
            if(Vector2.Distance(transform.position, target) < 0.3f)
            {
                if(target != (Vector2)target1.position)
                {
                    startPoint = target2.position;
                    endPoint = target1.position;
                }
                else
                {
                    startPoint = target1.position;
                    endPoint = target2.position;
                }
                stop = false;
            }
            startTime = Time.time;
        }
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void OnMouseDrag()
    {
        transform.position = mousePos;
        stop = true;
    }

    private void Settarget()
    {
        if(Vector2.Distance(transform.position, target1.position) < 0.3f)
        {
            target = target2.position;
        }
        if(Vector2.Distance(transform.position, target2.position) < 0.3f)
        {
            target = target1.position;
        }
    }
    private void Movement()
    {
        if(stop == false)
        {
            t = Mathf.PingPong((Time.time - startTime) * speed, 1f);
            Vector2 move = Vector2.Lerp(startPoint, endPoint, t);
            float curve = Mathf.Sin(t * Mathf.PI) *height;
            move.y += curve;
            transform.position = move;
        }
        
    }


    // void Start()
    // {
    //     target = target1.position;
    // }
 
    // void Update()
    // {
    //     Settarget();
    //     mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     rotateDir = target - (Vector2)transform.position;
    //     float angle = Mathf.Atan2(rotateDir.y, rotateDir.x) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.Euler(0, 0, angle);
    // }
    // void FixedUpdate()
    // {
    //     Movement();
    // }
 
    // private void OnMouseDrag()
    // {
    //     transform.position = mousePos;
    // }
 
    // private void Settarget()
    // {
    //     if(gameObject.transform.position == target1.position )
    //     {
    //         target = target2.position;
    //     }
    //     else if(gameObject.transform.position == target2.position)
    //     {
    //         target = target1.position;
    //     }
    // }
    // private void Movement()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    // }
}
