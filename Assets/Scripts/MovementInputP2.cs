using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputP2 : MonoBehaviour {

    public Movement movementScript;

    public float moveSpeed = 50f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal2");

        if (Input.GetButton("Jump2"))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

    }

    void FixedUpdate()
    {
        movementScript.Move(horizontalMove * moveSpeed * Time.fixedDeltaTime, false, jump);
    }
}
