using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            Camera.main.GetComponent<CameraTarget>().target = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Camera.main.GetComponent<CameraFollow>().enabled = true;
        }
    }
}