﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            Camera.main.transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
    }
}
