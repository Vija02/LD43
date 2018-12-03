using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameObject.Find("Player").transform.position = new Vector3(0, -30, 0);
            GameObject.Find("Player2").transform.position = new Vector3(0, -30, 0);
        }
    }
}
