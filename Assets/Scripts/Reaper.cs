using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper : MonoBehaviour
{
    public GameObject sacrificePanel;
    public GameObject sacrificePanel2;

    public MovingPlatform platformToMove;
    public GameObject platformToRemove;

    public int sacrificeNum = 1;

    // Sacrifice panel activated
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            sacrificePanel.GetComponent<AbilityController>().sacrificeOn = this;
            sacrificePanel2.GetComponent<AbilityController>().sacrificeOn = this;
            sacrificePanel.SetActive(true);
            sacrificePanel2.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            sacrificePanel.SetActive(false);
            sacrificePanel2.SetActive(false);
        }
    }

    public void OnSacrifice(GameObject player)
    {
        Camera.main.transform.GetChild(0).GetComponent<AudioSource>().Play();
        Camera.main.transform.GetChild(1).GetComponent<AudioSource>().Play();
        switch (sacrificeNum)
        {
            case 1: // Give hook
                player.GetComponent<GrapplingHook>().enableGrapplingHook = true;
                break;
            case 2: // Move platform
                platformToMove.MoveSpeed = 5;
                break;
            case 3: // Remove barrier
                platformToRemove.SetActive(false);
                break;
            default:
                break;
        }

        sacrificePanel.SetActive(false);
        sacrificePanel2.SetActive(false);
        gameObject.SetActive(false);
    }

}