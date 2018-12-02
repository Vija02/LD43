using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeDoubleJump : MonoBehaviour {

    [SerializeField]
    public GameObject player2;
    public Movement player2Movement;
    public GameObject player1;
    public GrapplingHook player1Hook;
    public AbilityController abilityController;

    public void Button_Onclick()
    {
        //On clicking the button
        //set enableDoubleJump to false

        
        abilityController.DisableDoubleJump(player2, player2Movement);
        abilityController.EnableHook(player1, player1Hook);
    }

}
