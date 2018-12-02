using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public Sprite[] sprite;
    public float timer;


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Flicks lever
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];

            //Code here

            //Release Lever
            StartCoroutine("Release");
               
        }
        
    }

    IEnumerator Release()
    {
        //Releases lever in X seconds
        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
    }

}
