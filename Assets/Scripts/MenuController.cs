using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void SelectSinglePlayer()
    {
        PlayerPrefs.SetInt("isVersusMode", 0);
        LoadNextScreen();
    }
    public void SelectMultiPlayer()
    {
        PlayerPrefs.SetInt("isVersusMode", 1);
        LoadNextScreen();
    }
    void LoadNextScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
