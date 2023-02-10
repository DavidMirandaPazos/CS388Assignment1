using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rbRef;

    public float speed = 10.0f;
    public float speedIncreasePerc = 0.1f;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rbRef = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-1.0f, 1.0f), 0).normalized;
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
        }
        else if (collision.gameObject.layer == 7)
        {
            if (direction.x > 0.0f)
                gameManager.AddScore(true);
            else
                gameManager.AddScore(false);

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

        gameObject.transform.position = Vector2.zero;
        speed = 10.0f;
    }
}
