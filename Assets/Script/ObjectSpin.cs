using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour {
    void Update() {
        transform.Rotate (Vector3.up * 25f * Time.deltaTime, Space.Self);
    }
}
