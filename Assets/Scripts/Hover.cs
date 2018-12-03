using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    Vector2 floatY;
    float originalY;

    public float floatStrength;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        floatY = transform.position;
        floatY.y = (Mathf.Sin(Time.time) * floatStrength) + originalY;
        transform.position = floatY;
    }
}
