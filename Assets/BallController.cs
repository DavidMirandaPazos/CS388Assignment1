using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManagerScript gameManager;
    Rigidbody rbRef;

    public float speed = 10.0f;
    public float speedIncreasePerc = 0.1f;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rbRef = gameObject.GetComponent<Rigidbody>();
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0,0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rbRef.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle collision with player
        if (other.gameObject.layer == 6)
        {
            speed += speedIncreasePerc;

            direction.x = (direction.x > 0.0f?-1.0f:1.0f);
            direction.y = gameObject.transform.position.y - other.gameObject.transform.position.y;

            direction = direction.normalized;
            rbRef.velocity = direction * speed;

            Debug.Log("New vector: " + direction);
            Debug.Log("Velocity: " + rbRef.velocity);
        }
        else if(other.gameObject.layer == 7)
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
            //rbRef.velocity = rbRef.velocity.normalized * speed;
        }
    }

    private void ResetPosition()
    {
        gameObject.transform.position = Vector3.zero;
        speed = 10.0f;
    }
}
