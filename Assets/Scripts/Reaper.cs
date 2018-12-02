using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper : MonoBehaviour
{
    public GameObject theReaper;
    [SerializeField]
    public FadeInScript fadein;
    [SerializeField]
    public FadeOutScript fadeout;

    private void Awake()
    {
        fadein = theReaper.GetComponent<FadeInScript>();
        fadeout = theReaper.GetComponent<FadeOutScript>();
    }

    void Start()
    {
        theReaper.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            theReaper.SetActive(true);
            fadein.StartCoroutine("FadeIn");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            fadeout.StartCoroutine("FadeOut");
        }
        
    }
}