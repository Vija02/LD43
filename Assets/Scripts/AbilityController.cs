using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public GameObject Player1;
    public Movement Player1Movement;

    public GrapplingHook Player1GrappingHook;
    public GrapplingHook Player2GrappingHook;

    public GameObject Player2;
    public Movement Player2Movement;

    public void EnableDoubleJump(GameObject player, Movement playermovement)
    {
        playermovement.enableDoubleJump = true;
    }

    public void DisableDoubleJump(GameObject player, Movement playermovement)
    {
        playermovement.enableDoubleJump = false;
    }

    public void EnableHook(GameObject player, GrapplingHook hook)
    {
        hook.enableGrapplingHook = true;
    }

    public void DisableHook(GameObject player, GrapplingHook hook)
    {
        hook.enableGrapplingHook = false;
    }

    // Use this for initialization
    void Start()
    {
        EnableDoubleJump(Player1, Player1Movement);
        EnableHook(Player2, Player2GrappingHook);

        DisableDoubleJump(Player2, Player2Movement);
        DisableHook(Player1, Player1GrappingHook);

    }

    //Every button in the menu leads to here
	
}
