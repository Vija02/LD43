using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper : MonoBehaviour
{
    public GameObject theReaper;
    public GameObject sacrificePanel;
    public FadeInScript fadein;
    public FadeOutScript fadeout;

    private void Awake()
    {
        fadein = theReaper.GetComponent<FadeInScript>();
        fadeout = theReaper.GetComponent<FadeOutScript>();
    }

    void Start()
    {
        //Disable Reaper
        theReaper.SetActive(false);
    }

    //Reaper Fades in, Sacrifice panel activated
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            theReaper.SetActive(true);
            sacrificePanel.SetActive(true);
            fadein.StartCoroutine("FadeIn");
        }
    }

      //Reaper Fades out
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            fadeout.StartCoroutine("FadeOut");
        }
        
    }
}