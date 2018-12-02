using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    public Transform TeleportTarget;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = TeleportTarget.transform.position;
    }
}
