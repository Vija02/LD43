using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper : MonoBehaviour
{
    public GameObject theReaper;
    void Start()
    {
        theReaper.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        theReaper.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        theReaper.SetActive(false);
    }
}