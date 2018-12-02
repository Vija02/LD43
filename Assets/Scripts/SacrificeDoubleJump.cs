using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeDoubleJump : MonoBehaviour {

    [SerializeField]
    public GameObject player;
    public Movement movementScript;

    public void Button_Onclick()
    {
        //On clicking the button
        //set enableDoubleJump to false
        movementScript.enableDoubleJump = false;
    }

}
