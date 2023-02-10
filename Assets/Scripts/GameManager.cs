using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallController ball;
    public UnityEngine.UI.Text score1;
    public UnityEngine.UI.Text score2;
    public GameObject prefab;

    public float radious = 5.0f;

    public int maxScore = 10;
    Vector2Int scores = Vector2Int.zero;

    private void Start()
    {

        for(int i = 0; i < maxScore; i++)
        {
            GameObject obj =Instantiate(prefab, new Vector3(radious * Mathf.Cos(2.0f * i * Mathf.PI/ maxScore), radious * Mathf.Sin(2.0f * i * Mathf.PI / maxScore), 0.0f), Quaternion.identity);
            GoalController goalRef = obj.GetComponent<GoalController>();
            goalRef.gameManager = this;
            goalRef.ball = ball;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore(bool isPlayer1)
    {
        if (isPlayer1)
        {
            scores.x++;
            score1.text = scores.x.ToString();
        }
        else
        {
            scores.y++;
            score2.text = scores.y.ToString();
        }

        if (scores.x >= maxScore)
            PlayerWon(true);
        else if(scores.y>= maxScore)
            PlayerWon(false);
    }

    void PlayerWon(bool isPlayer1)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
