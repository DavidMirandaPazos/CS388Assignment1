using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    SpriteRenderer renderer;

    public BallController ball;
    public GameManager gameManager;
    public Color goalColor;
    bool isGoaled;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isGoaled)
        {
            isGoaled = true;
            renderer.color = goalColor;
            Debug.Log("Color: " + goalColor);

            if (ball.direction.x < 0.0f)
                gameManager.AddScore(false);
            else
                gameManager.AddScore(true);
        }
        else
        {
            ball.direction.x = -ball.direction.x;
            ball.rbRef.velocity = ball.direction * ball.speed;
        }
    }


}
