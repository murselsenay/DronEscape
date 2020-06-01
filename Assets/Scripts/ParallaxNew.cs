using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxNew : MonoBehaviour
{
    public float speed = 0;
    public float targetSpeed = 0;
    float speedStepSize = 0.001f; // Change as needed based on how quickly speed should change

    void Start()
    {
        
    }

    void Update()
    {
        float x = Mathf.Repeat((Time.time * speed), 1);
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(x, 0f);

        if (targetSpeed < speed)
        {
            speed = Mathf.Max(speed - speedStepSize, targetSpeed);
        }
        else if (targetSpeed > speed)
        {
            speed = Mathf.Min(speed + speedStepSize, targetSpeed);
        }
    }

    public void SetTargetSpeed(float newSpeed)
    {
        targetSpeed = newSpeed;
    }
}
