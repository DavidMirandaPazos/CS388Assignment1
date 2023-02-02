using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectMenu : MonoBehaviour
{
    public void SelectSinglePlayer()
    {
        PlayerPrefs.SetInt("isSingleMode", 0);
        LoadNextScreen();
    }
    public void SelectMultiPlayer()
    {
        PlayerPrefs.SetInt("isSingleMode", 1);
        LoadNextScreen();
    }

    void LoadNextScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
