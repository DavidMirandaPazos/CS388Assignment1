using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public bool finishedFadeIn = false;

    private void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeImage(true, 0));
    }
    public void FadeOut(int nextScene)
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeImage(false, nextScene));
    }

    IEnumerator FadeImage(bool fadeIn, int nextScene)
    {
        if(fadeIn)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(image.color.r, image.color.g, image.color.b, i);
                yield return null;
            }
            gameObject.SetActive(false);
            finishedFadeIn = true;
        }
        else
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(image.color.r, image.color.g, image.color.b, i);
                yield return null;
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
