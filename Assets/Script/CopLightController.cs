using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopLightController : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
