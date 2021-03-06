﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraTrigger : MonoBehaviour
{

    bool cameraShouldTarget = false;

    private bool tped = false;
    private int numOfPlayerInside = 0;

    public GameObject tpPoint;

    private void Update()
    {
        if (cameraShouldTarget)
        {
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            Camera.main.GetComponent<CameraTarget>().target = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            numOfPlayerInside++;

            cameraShouldTarget = true;

            if (tped || !tpPoint)
            {
                return;
            }

            // TP the other player to the screen 
            GameObject playerToTp;

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players[0].transform == collision.transform)
            {
                playerToTp = players[1];
            }
            else
            {
                playerToTp = players[0];
            }

            playerToTp.transform.position = tpPoint.transform.position;
            tped = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            cameraShouldTarget = false;

            numOfPlayerInside--;

            Camera.main.GetComponent<CameraFollow>().enabled = true;

            if(numOfPlayerInside == 0)
            {
                tped = false;
            }
            
        }
    }
}