using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutScript : MonoBehaviour {

    SpriteRenderer rend;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        
    }

    //Slowly fade out the sprite
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= speed)
        {
            //change c's alpha value
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartFading()
    {
        //Add trigger here
        StartCoroutine("FadeOut");
    }
}
