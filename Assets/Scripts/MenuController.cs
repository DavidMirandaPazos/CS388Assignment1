using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Fade fader;

    public void SelectSinglePlayer()
    {
        PlayerPrefs.SetInt("isVersusMode", 0);
        fader.FadeOut(2);
    }
    public void SelectMultiPlayer()
    {
        PlayerPrefs.SetInt("isVersusMode", 1);
        fader.FadeOut(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
