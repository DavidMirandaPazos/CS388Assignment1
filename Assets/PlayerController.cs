using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
#if !UNITY_ANDROID
    // Input vars
    public KeyCode upKey;
    public KeyCode downKey;

    //Movement vars
    public float speed = 10.0f;
    public Vector3 tempPosition;

    public Vector2 verticalLimits = new Vector2(-3.0f,5.0f);

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
        if (Input.GetKey(upKey))
           tempPosition += Vector3.up * speed * Time.deltaTime;
        // Move downward
        if (Input.GetKey(downKey))
            tempPosition -= Vector3.up * speed * Time.deltaTime;
     }
#endif
}
