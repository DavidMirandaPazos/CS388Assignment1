using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Fade fader;
    public BallController ball;
    public UnityEngine.UI.Text score1;
    public UnityEngine.UI.Text score2;
    public GameObject prefab;

    public float radious = 5.0f;

    public int maxScore = 5;
    Vector2Int scores = Vector2Int.zero;

    private void Start()
    {
        ball.gameObject.SetActive(false);
        int map = Random.Range(0, 2);

        if(map == 0)
        {
            instantiateScorePoint(new Vector3(0.0f, 12.0f, 0.0f));
            instantiateScorePoint(new Vector3(0.0f, 6.0f, 0.0f));
            instantiateScorePoint(new Vector3(3.0f, 9.0f, 0.0f));
            instantiateScorePoint(new Vector3(-3.0f, 9.0f, 0.0f));

            instantiateScorePoint(new Vector3(0.0f, -12.0f, 0.0f));
            instantiateScorePoint(new Vector3(0.0f, -6.0f, 0.0f));
            instantiateScorePoint(new Vector3(3.0f, -9.0f, 0.0f));
            instantiateScorePoint(new Vector3(-3.0f, -9.0f, 0.0f));

            instantiateScorePoint(new Vector3(11.0f, 4.0f, 0.0f));
            instantiateScorePoint(new Vector3(11.0f, -4.0f, 0.0f));
            instantiateScorePoint(new Vector3(-11.0f, 4.0f, 0.0f));
            instantiateScorePoint(new Vector3(-11.0f, -4.0f, 0.0f));
        }
        else if (map == 1)
        {
            instantiateScorePoint(new Vector3(0.0f, 12.0f, 0.0f));
            instantiateScorePoint(new Vector3(9.0f, 9.0f, 0.0f));
            instantiateScorePoint(new Vector3(-9.0f, 9.0f, 0.0f));

            instantiateScorePoint(new Vector3(0.0f, 3.0f, 0.0f));
            instantiateScorePoint(new Vector3(0.0f, -3.0f, 0.0f));

            instantiateScorePoint(new Vector3(0.0f, -12.0f, 0.0f));
            instantiateScorePoint(new Vector3(9.0f, -9.0f, 0.0f));
            instantiateScorePoint(new Vector3(-9.0f, -9.0f, 0.0f));
        }
        else if (map == 2)
        {
            instantiateScorePoint(new Vector3(16.0f, 9.0f, 0.0f));
            instantiateScorePoint(new Vector3(16.0f, -9.0f, 0.0f));
            instantiateScorePoint(new Vector3(-16.0f, 9.0f, 0.0f));
            instantiateScorePoint(new Vector3(-16.0f, -9.0f, 0.0f));

            instantiateScorePoint(new Vector3(12.0f, 5.0f, 0.0f));
            instantiateScorePoint(new Vector3(12.0f, -5.0f, 0.0f));
            instantiateScorePoint(new Vector3(-12.0f, 5.0f, 0.0f));
            instantiateScorePoint(new Vector3(-12.0f, -5.0f, 0.0f));

            instantiateScorePoint(new Vector3(0.0f, 11.0f, 0.0f));
            instantiateScorePoint(new Vector3(0.0f, -11.0f, 0.0f));

            instantiateScorePoint(new Vector3(0.0f, 0.0f, 0.0f));
        }
    }

    private void instantiateScorePoint(Vector3 position)
    {
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        GoalController goalRef = obj.GetComponent<GoalController>();
        goalRef.gameManager = this;
        goalRef.ball = ball;
    }


    // Update is called once per frame
    void Update()
    {
        if (fader.finishedFadeIn)
            ball.gameObject.SetActive(true);
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
        fader.FadeOut(0);
    }
}
