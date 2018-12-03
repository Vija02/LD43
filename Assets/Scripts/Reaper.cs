using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper : MonoBehaviour
{
    public GameObject sacrificePanel;

    public MovingPlatform platformToMove;

    public int sacrificeNum = 1;

    // Sacrifice panel activated
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            sacrificePanel.GetComponent<AbilityController>().sacrificeOn = this;
            sacrificePanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            sacrificePanel.SetActive(false);
        }
    }

    public void OnSacrifice(GameObject player)
    {
        switch (sacrificeNum)
        {
            case 1: // Give hook
                player.GetComponent<GrapplingHook>().enableGrapplingHook = true;
                break;
            case 2: // Move platform
                platformToMove.MoveSpeed = 5;
                break;
            default:
                break;
        }

        sacrificePanel.SetActive(false);
        gameObject.SetActive(false);
    }

}