using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    public Vector3 target = Vector3.zero;
    public float smoothTime = 0.4F;
    private Vector3 velocity = Vector3.zero;

    void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
    }
}
