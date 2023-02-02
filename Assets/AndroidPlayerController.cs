using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerController : MonoBehaviour
{
#if UNITY_ANDROID

    //Movement vars
    public float speed = 10.0f;
    public Vector3 tempPosition;

    public Vector2 verticalLimits = new Vector2(-4.0f, 4.0f);

    public GameObject ball;

    public bool isLeft;

    int versusMode;

    // Start is called before the first frame update
    // This should be called Initialize
    void Start()
    {
        versusMode = PlayerPrefs.GetInt("isSingleMode");

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
            float isDown = Input.touches[i].position.y < Screen.height / 2.0f?-1.0f:1.0f;
            bool isRight = Input.touches[i].position.x < Screen.width / 2.0f;

            if (isLeft && !isRight)
                tempPosition += isDown * Vector3.up * speed * Time.deltaTime;
            else if(!isLeft && isRight && versusMode == 1)
                tempPosition += isDown * Vector3.up * speed * Time.deltaTime;
        }
    }
    void UpdateAI()
    {
        tempPosition.y = ball.transform.position.y;
    }

#endif
}
