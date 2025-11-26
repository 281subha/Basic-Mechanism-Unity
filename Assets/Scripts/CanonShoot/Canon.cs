using System;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject cannonBall;
    private GameObject newBall;
    private Rigidbody2D ballRb;
    public Transform firepoint;
    public Transform pivot;
    private Vector2 mousePos;
    private Vector2 rotateDirection;
    public float speed = 5f;
    private float bound = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotateDirection = mousePos - (Vector2)pivot.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, 30, 150);
        pivot.rotation = Quaternion.Euler(0, 0, clampedAngle-90f);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        newBall = Instantiate(cannonBall, firepoint.position, cannonBall.transform.rotation);
        ballRb = newBall.GetComponent<Rigidbody2D>();
        ballRb.AddForce(rotateDirection * speed, ForceMode2D.Impulse);

        if(newBall.transform.position.x >= bound )
        {
            Debug.Log("destroy");
            Destroy(newBall);
        }
    }
}
