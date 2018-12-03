using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject Platform;

    public float MoveSpeed;

    public float delay = 0;
    private float currentDelay = 0;

    public Transform CurrentPoint;

    public Transform[] Points;

    public int PointSelection;

	// Use this for initialization
	void Start () {
        CurrentPoint = Points[PointSelection];
	}
	
	// Update is called once per frame
	void Update () {
        

        if(currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
            return;
        }

        //Move dTime * speed each frame
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position,CurrentPoint.position, Time.deltaTime * MoveSpeed);

        if (Platform.transform.position == CurrentPoint.position)
        {
            currentDelay = delay;
            //Only allows two states (0, 1)
            PointSelection = (PointSelection + 1) % Points.Length;

            CurrentPoint = Points[PointSelection];
        }
    }
}
