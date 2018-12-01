using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour {

    [SerializeField]
    public Rigidbody2D rBody;



	// Use this for initialization
	void Start () {
        rBody.mass = 0.8f;
        rBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
            
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rBody.isKinematic = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rBody.isKinematic = true;
            rBody.velocity = Vector3.zero;
            rBody.angularVelocity = 0;
        }
    }

}
