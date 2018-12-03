using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodySleep : MonoBehaviour {

    [SerializeField]
    public Rigidbody2D rBody;

    public bool canHold = false;

    public static bool enablePushP1 = true;
    public static bool enablePushP2 = true;

    // Use this for initialization
    void Start () {
        rBody.mass = 0.8f;
        rBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {

        //When left shift is clicked, enable physics
        if ((enablePushP1 && Input.GetButtonDown("Action")) || (enablePushP2 && Input.GetButtonDown("Action2")))
        {
            rBody.isKinematic = false;
        }

        //When realsed, the block could no longer be moved
        if (!Input.GetButton("Action") && !Input.GetButton("Action2"))
        {
            StopMoving();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            canHold = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            canHold = false;
            StopMoving();
        }
    }

    private void StopMoving()
    {
        rBody.isKinematic = true;
        rBody.velocity = Vector3.zero;
        rBody.angularVelocity = 0;
        rBody.Sleep();
    }

}
