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
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	// Update is called once per frame
	void Update () {

        //When left shift is clicked, enable physics
        if (canHold && ((enablePushP1 && Input.GetButtonDown("Action")) || (enablePushP2 && Input.GetButtonDown("Action2"))))
        {
            rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //When realsed, the block could no longer be moved
        if (!Input.GetButton("Action") && !Input.GetButton("Action2"))
        {
            StopMoving();
        }
    }

    // Let the player stick to the moving platform once they collided //
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Moving Platform")
        {
            transform.parent = other.transform;
        }

    }

    // Free the player when it jumps off //
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Moving Platform")
        {
            transform.parent = null;
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
        rBody.constraints = RigidbodyConstraints2D.FreezeAll;
        rBody.velocity = Vector3.zero;
        rBody.angularVelocity = 0;
        rBody.Sleep();
    }

}
