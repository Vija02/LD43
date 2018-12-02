using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : MonoBehaviour {

    public GameObject Bar;


    public Transform CurrentPoint;

    public Transform[] points;

    public int pointSelection;

	// Use this for initialization
	void Start () {
        CurrentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {

        if(Bar.transform.position == CurrentPoint.position)
        {
             pointSelection = (pointSelection + 1) % 2;
            
             CurrentPoint = points[pointSelection];
        }
    }

    // Bar moves in and out when player clicks the button
    public void OnClick()
    {
        while (Bar.transform.position != CurrentPoint.position)
        {
            Bar.transform.position = Vector3.MoveTowards(Bar.transform.position, CurrentPoint.position, Time.deltaTime);
        }

    }

}
