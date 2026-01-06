using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 mousePos;
    private float speed = 1.5f;
    // private float smoothTime = 1f;
    // private Vector2 velocity = Vector2.zero;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movePlayer();
    }
    private void movePlayer()
    {
        transform.position = Vector2.Lerp(transform.position, mousePos, speed * Time.deltaTime);
        // transform.position = Vector2.SmoothDamp(transform.position, mousePos, ref velocity, smoothTime);
    }
}
