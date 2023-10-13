using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotationController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed, 0, 0);
    }
}
