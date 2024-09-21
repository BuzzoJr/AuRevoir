using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotationController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float rotationSpeedY = 0f;
    public float rotationSpeedZ = 0f;

    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed, rotationSpeedY, rotationSpeedZ);
    }
}
