using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerController : MonoBehaviour
{
    //Movement vars
    public Vector2 verticalLimits = new Vector2(-13.0f, 13.0f);
    public float speed = 10.0f;

    public GameObject ball;

    public bool isLeft;

    Vector3 tempPosition;
    int versusMode;

#if UNITY_ANDROID
    // Start is called before the first frame update
    // This should be called Initialize
    void Start()
    {
        versusMode = PlayerPrefs.GetInt("isVersusMode");

        tempPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        if (!isLeft && versusMode == 0)
            UpdateAI();
    }

    private void LateUpdate() // prevent fails, safe checks
    {
        transform.position = tempPosition;
        tempPosition.y = Mathf.Clamp(tempPosition.y, verticalLimits.x, verticalLimits.y);
    }

    // This is called at the same time as the PSX updates, but after the object's PSX update.
    private void FixedUpdate() // anything related to physics
    {
    }

    void CheckMovement()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            bool isDown = Input.touches[i].position.y < Screen.height / 2.0f;
            bool isRight = Input.touches[i].position.x > Screen.width / 2.0f;

            // Left player input
            if (isLeft) //&& !isRight && tempPosition.y < verticalLimits.y && tempPosition.y > verticalLimits.x)
            {
                if (!isRight)
                {
                    if (isDown && tempPosition.y > verticalLimits.x)
                        tempPosition -= Vector3.up * speed * Time.deltaTime;
                    else if (tempPosition.y < verticalLimits.y)
                        tempPosition += Vector3.up * speed * Time.deltaTime;
                }
            }
            else if (versusMode == 1)
            {
                if (isRight)
                {
                    if (isDown && tempPosition.y > verticalLimits.x)
                        tempPosition -= Vector3.up * speed * Time.deltaTime;
                    else if (tempPosition.y < verticalLimits.y)
                        tempPosition += Vector3.up * speed * Time.deltaTime;
                }
            }
            else if(versusMode == 0)
                UpdateAI();
        }
    }
    void UpdateAI()
    {
        tempPosition.y = ball.transform.position.y;
    }

#endif
}
