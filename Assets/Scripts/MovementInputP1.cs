using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputP1 : MonoBehaviour
{
    public Movement movementScript;

    public float moveSpeed = 50f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump"))
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
