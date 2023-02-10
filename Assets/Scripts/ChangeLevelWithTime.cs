using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelWithTime : MonoBehaviour
{
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 5.0f)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        else
            currentTime += Time.deltaTime;
    }
}
