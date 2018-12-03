using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public GameObject player;
    public int playerNum = 1;

    public Movement movement;
    public GrapplingHook hook;

    public GameObject DBJUI;
    public GameObject jumpUI;
    public GameObject walkUI;
    public GameObject pushUI;
    public GameObject hookUI;

    public Reaper sacrificeOn;

    void Update()
    {
        DBJUI.SetActive(movement.enableDoubleJump);
        jumpUI.SetActive(movement.enableJump);
        walkUI.SetActive(movement.enableWalk);
        if(playerNum == 1)
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
        sacrificeOn.OnSacrifice(player);
    }
    public void DisableJump()
    {
        movement.enableJump = false;
        sacrificeOn.OnSacrifice(player);
    }
    public void DisableWalk()
    {
        movement.enableWalk = false;
        sacrificeOn.OnSacrifice(player);
    }
    public void DisablePush()
    {
        if (playerNum == 1)
        {
            RigidBodySleep.enablePushP1 = false;
        }
        else
        {
            RigidBodySleep.enablePushP2 = false;
        }
        sacrificeOn.OnSacrifice(player);

    }
    public void DisableHook()
    {
        hook.enableGrapplingHook = false;
        sacrificeOn.OnSacrifice(player);
    }

}
