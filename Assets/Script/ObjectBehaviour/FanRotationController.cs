using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotationController : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed, 0, 0);
    }
}
