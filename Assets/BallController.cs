using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManagerScript gameManager;
    Rigidbody rbRef;

    public float speed = 10.0f;
    public float speedIncreasePerc = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rbRef = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rbRef.velocity = Vector3.left * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle collision with player
        if (other.gameObject.layer == 6)
        {
            speed *= -1.0f * (1.0f + speedIncreasePerc);

            Vector3 xd = new Vector3(1, other.gameObject.transform.position.y - gameObject.transform.position.y, 0).normalized;

            Debug.Log("New vector: " + xd);
            rbRef.velocity = xd * speed;
        }
        else if(other.gameObject.layer == 7)
        {
            if (speed < 0.0f)
                gameManager.AddScore(true);
            else
                gameManager.AddScore(false);

            // Do something about point
            ResetPosition();
        }
        // Collided with wall
        else
        {
            speed *= -1.0f * (1.0f + speedIncreasePerc);
            rbRef.velocity = rbRef.velocity.normalized * speed;
        }
    }

    private void ResetPosition()
    {
        gameObject.transform.position = Vector3.zero;
        speed = 10.0f;
    }
}
