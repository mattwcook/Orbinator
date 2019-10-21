using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpin : MonoBehaviour

    // Make the earth spin to give the realtive impression that the ship
    // and debris are orbiting around it.
{
    public float rotationalSpeed; // degrees per second
    float rotationPosition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationPosition -= rotationalSpeed * Time.deltaTime;
        if (rotationPosition <= -360)
        {
            rotationPosition += 360.0f;
        }
        transform.localRotation = Quaternion.Euler(0.0f, rotationPosition, 0.0f);
    }
}
