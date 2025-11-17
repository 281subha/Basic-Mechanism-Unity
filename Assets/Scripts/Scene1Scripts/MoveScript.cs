using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector3 ownPos;
    public Transform bottomRight;
    public Transform topRight;
    public Transform topLeft;
    public float moveSpeed;
    private Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ownPos = transform.position;
        targetPosition = bottomRight.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetNewPosition();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void SetNewPosition()
    {
        if (transform.position == targetPosition)
        {
            targetPosition = topRight.position;
        }
        if(transform.position == topRight.position)
        {
            targetPosition = topLeft.position;
        }
        if(transform.position == topLeft.position)
        {
            targetPosition = ownPos;
        }
        if(transform.position == ownPos)
        {
            targetPosition = bottomRight.position;
        }
    }

    void MovePlayer()
    {
        Vector2 currentPosition = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        transform.position = currentPosition;
    }
}
