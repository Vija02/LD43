using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessageScript : MonoBehaviour {

    public GameObject messageBox;
    public FadeInScript fadein;
    public FadeOutScript fadeout;

    // Use this for initialization
    void Start () {
        fadein = messageBox.GetComponent<FadeInScript>();
        fadeout = messageBox.GetComponent<FadeOutScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fadein.StartCoroutine("FadeIn");

    }

    void OnTriggerExit2D(Collider2D collision)
    {
       fadeout.StartCoroutine("FadeOut");
        

    }
}
