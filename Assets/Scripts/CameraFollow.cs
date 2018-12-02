using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform target;

    public Camera cam;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float camWidth = cam.orthographicSize;
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin - camWidth, xMax + camWidth), Mathf.Clamp(target.position.y, yMin,yMax), transform.position.z);
	}
}

