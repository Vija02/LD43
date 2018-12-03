using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraTrigger : MonoBehaviour
{

    private bool tped = false;
    private int numOfPlayerInside = 0;

    public GameObject tpPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            numOfPlayerInside++;

            Camera.main.GetComponent<CameraFollow>().enabled = false;
            Camera.main.GetComponent<CameraTarget>().target = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

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
            Debug.Log("exit");
            Debug.Log(collision.gameObject.name);
            numOfPlayerInside--;

            Camera.main.GetComponent<CameraFollow>().enabled = true;

            if(numOfPlayerInside == 0)
            {
                tped = false;
            }
            
        }
    }
}