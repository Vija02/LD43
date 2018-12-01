using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    public Sprite[] current_texture;
    bool flicked;

    private void Start()
    {
        flicked = false;
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            flicked = !flicked;

            //if not flicked, once pressed E, flicks lever
            if (flicked == true) {
            gameObject.GetComponent<SpriteRenderer>().sprite = current_texture[1];
                //add code here
            }
            //If flicked, once pressed E, flicks it back
            else
            {
            gameObject.GetComponent<SpriteRenderer>().sprite = current_texture[0];
                //add code here
            }





        }
    }
}
