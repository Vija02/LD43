using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]
    private float minHeightAllowed;
    [SerializeField]
    private GameObject[] respawnBlocks;

    public static Vector3 respawnPoint;
    private Vector3[] originalBlockPos;

    void Start()
    {
        respawnPoint = transform.position;
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
