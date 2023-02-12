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
    public float speed = 30.0f;

    Vector3 tempPosition;
    GameObject ball;

#if !UNITY_ANDROID

    // Start is called before the first frame update
    // This should be called Initialize
    void Start()
    {
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        tempPosition.y = ball.transform.position.y;
    }
#endif
}
