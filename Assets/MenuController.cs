using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public UnityEngine.UI.Text startText;

    private void Start()
    {
        #if UNITY_EDITOR
        startText.text = "Press SPACE to continue";
        #endif
        #if UNITY_ANDROID
        startText.text = "Touch scrren to continue";
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        # if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        #endif

        # if UNITY_ANDROID
        if(Input.touchCount == 1)
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        if (Input.touchCount == 2)
            Application.Quit();
        #endif
    }
}
