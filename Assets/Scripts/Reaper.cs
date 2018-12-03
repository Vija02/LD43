using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper : MonoBehaviour
{
    public GameObject sacrificePanel;

    // Sacrifice panel activated
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
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

}