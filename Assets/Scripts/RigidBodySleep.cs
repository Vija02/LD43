using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodySleep : MonoBehaviour {

    [SerializeField]
    public Rigidbody2D rBody;

    public bool canHold = false;

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
            stopMoving();
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
            stopMoving();
        }
    }

    private void stopMoving()
    {
        rBody.isKinematic = true;
        rBody.velocity = Vector3.zero;
        rBody.angularVelocity = 0;
        rBody.Sleep();
    }

}
