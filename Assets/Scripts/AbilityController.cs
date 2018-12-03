using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public int player = 1;

    public Movement movement;
    public GrapplingHook hook;

    public GameObject DBJUI;
    public GameObject jumpUI;
    public GameObject walkUI;
    public GameObject pushUI;
    public GameObject hookUI;

    void Update()
    {
        DBJUI.SetActive(movement.enableDoubleJump);
        jumpUI.SetActive(movement.enableJump);
        walkUI.SetActive(movement.enableWalk);
        if(player == 1)
        {
            pushUI.SetActive(RigidBodySleep.enablePushP1);
        }
        else
        {
            pushUI.SetActive(RigidBodySleep.enablePushP2);
        }
        hookUI.SetActive(hook.enableGrapplingHook);
    }

    public void DisableDBJ()
    {
        movement.enableDoubleJump = false;
    }
    public void DisableJump()
    {
        movement.enableJump = false;
    }
    public void DisableWalk()
    {
        movement.enableWalk = false;
    }
    public void DisablePush()
    {
        if (player == 1)
        {
            RigidBodySleep.enablePushP1 = false;
        }
        else
        {
            RigidBodySleep.enablePushP2 = false;
        }
        
    }
    public void DisableHook()
    {
        hook.enableGrapplingHook = false;
    }

}
