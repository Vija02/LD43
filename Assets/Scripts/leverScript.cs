using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverScript : MonoBehaviour {

    public Sprite[]  current_texture;
    bool flicked;

	// Use this for initialization
	void Start () {
        flicked = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            flicked = !flicked;
            if (flicked)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = current_texture[1];
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = current_texture[0];
            }
                
        }
	}
}
