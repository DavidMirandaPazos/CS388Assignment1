using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    Vector2Int scores = Vector2Int.zero;

    public UnityEngine.UI.Text scorerText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(true);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
            AddScore(false);
    }

    public void AddScore(bool player1)
    {
        if (player1)
            scores.x++;
        else
            scores.y++;

        // Handle any of the players winning the match
        if(scores.x >= 4 )
            PlayerWon(true);
        else if(scores.y >= 4)
            PlayerWon(false);

        // Update UI
        scorerText.text = scores.x + " - " + scores.y;
    }

    void PlayerWon(bool player1)
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
