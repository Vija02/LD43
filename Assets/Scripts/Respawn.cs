using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]
    private float minHeightAllowed;
    [SerializeField]
    public Vector3 respawnPoint;
    [SerializeField]
    private GameObject[] respawnBlocks;

    private Vector3[] originalBlockPos;

    void Start()
    {
         originalBlockPos = new Vector3[respawnBlocks.Length];
         for(int i=0; i<respawnBlocks.Length; i++)
         {
             originalBlockPos[i] = respawnBlocks[i].transform.position;
         }

    }

    void Update()
    {
        if (transform.position.y < minHeightAllowed)
        {
              for (int i = 0; i < respawnBlocks.Length; i++)
              {
                  respawnBlocks[i].transform.position = originalBlockPos[i];
              } 

            transform.position = respawnPoint;
        }
    }
}
