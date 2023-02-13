using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Input vars
    public KeyCode upKey;
    public KeyCode downKey;

    //Movement vars
    public Vector2 verticalLimits = new Vector2(-13.0f, 13.0f);
    public float speed = 10.0f;

    Vector3 tempPosition;
    public GameObject ball;

    public bool isLeft;
    int versusMode;

#if !UNITY_ANDROID

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
        if (!isLeft && versusMode == 0)
            UpdateAI();
        else
            CheckMovement();
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
        // Move upward
        if (Input.GetKey(upKey) && tempPosition.y < verticalLimits.y)
            tempPosition += Vector3.up * speed * Time.deltaTime;
        // Move downward
        else if (Input.GetKey(downKey) && tempPosition.y > verticalLimits.x)
            tempPosition -= Vector3.up * speed * Time.deltaTime;
    }
    void UpdateAI()
    {
        float differenece = Mathf.Abs(ball.transform.position.y - transform.position.y);
        if (differenece >= 1.5f )
        {
            float direction = -1.0f;

            if (ball.transform.position.y > transform.position.y)
                direction = 1.0f;

            tempPosition.y += direction * speed / 2 * Time.deltaTime;
        }
    }
#endif
}
