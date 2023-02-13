using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public BallController ball;
    public GameManager gameManager;
    public Color goalColor;
    private Color initialColor;
    bool isGoaled;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
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
            spriteRenderer.color = goalColor;
            //gameManager.AddScore(ball.lastTouchedLeft);
        }
        else
        {
            Vector2 direction = new Vector2(ball.transform.position.x - gameObject.transform.position.x, ball.transform.position.y - gameObject.transform.position.y);
            ball.direction = direction.normalized;
            ball.speed += ball.bounceSpeedIncrease;
            ball.rbRef.velocity = direction * ball.speed;
            spriteRenderer.color = initialColor;
            isGoaled = false;
        }
    }


}
