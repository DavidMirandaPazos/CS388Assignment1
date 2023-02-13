using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelWithTime : MonoBehaviour
{
    public Fade fader;

    float currentTime;

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 5.0f)
            fader.FadeOut(1);
        else
            currentTime += Time.deltaTime;
    }
}
