using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rbRef;
    public GameObject  playerLeft;
    public GameObject  playerRight;

    public float speed = 10.0f;
    public float speedIncreasePerc = 0.1f;

    private bool lastTouchedLeft = true;

    public Vector2 startPointLeft;
    public Vector2 startPointRight;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rbRef = gameObject.GetComponent<Rigidbody2D>();
        float direction_x = Random.Range(-1.0f, 1.0f);
        if(direction_x <= 0)
            gameObject.transform.position = startPointLeft;
        else
            gameObject.transform.position = startPointRight;
        direction = new Vector2(direction_x, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rbRef.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with player
        if (collision.gameObject.layer == 6)
        {
            speed += speedIncreasePerc;

            direction.x = (direction.x > 0.0f ? -1.0f : 1.0f);

            ContactPoint2D contactPoint = collision.GetContact(0);

            direction.y = contactPoint.point.y - collision.gameObject.transform.position.y ;
            Debug.Log("New Vertical: " + direction.y);

            direction = direction.normalized;
            rbRef.velocity = direction * speed;

            lastTouchedLeft = collision.gameObject.GetComponent<AndroidPlayerController>().isLeft;
        }
        else if (collision.gameObject.layer == 7)
        {
            gameManager.AddScore(lastTouchedLeft);

            // Do something about point
            ResetPosition();
        }
        // Collided with wall
        else
        {
            direction.y *= -1.0f;
            rbRef.velocity = rbRef.velocity.normalized * speed;
        }
    }

    private void ResetPosition()
    {
        direction.y = 0.0f;
        direction.Normalize();

        if(lastTouchedLeft)
            gameObject.transform.position = startPointRight;
        else
            gameObject.transform.position = startPointLeft;

        //reset player positions
        //Debug.Log("POSITION1: " + playerRight.transform.position);
        //playerLeft.transform.position = new Vector2(-24, 0);
        //playerRight.transform.position = new Vector2(24, 0);
        //Debug.Log("POSITION2: " + playerRight.transform.position);

        speed = 10.0f;
    }
}
