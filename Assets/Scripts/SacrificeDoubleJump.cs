using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeDoubleJump : MonoBehaviour {

    [SerializeField]
    public GameObject player;
    public Movement playerMovement;
    public AbilityController abilityController;

    public void Button_Onclick()
    {
        //On clicking the button
        //set enableDoubleJump to false

        
        abilityController.DisableDoubleJump(player, playerMovement);
    }

}
