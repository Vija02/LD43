using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]
    private float minHeightAllowed;
    [SerializeField]
    private Vector3 respawnPoint;

    void Update()
    {
        if (transform.position.y < minHeightAllowed)
        {

            transform.position = respawnPoint;

        }
    }
}
