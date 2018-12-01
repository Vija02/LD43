using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]
    private float minHeightAllowed;
    [SerializeField]
    private Vector3 respawnPoint;

    GameObject block;

    void Start()
    {
        block = GameObject.Find("face-block");
    }

    void Update()
    {
        if (transform.position.y < minHeightAllowed)
        {
            transform.position = respawnPoint;
            block.transform.position = new Vector3(1.75f, -1.523046f, 0);
        }
    }
}
