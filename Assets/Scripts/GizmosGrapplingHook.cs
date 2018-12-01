using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosGrapplingHook : MonoBehaviour {

    public float gizmosSize = 0.15f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, gizmosSize);
    }
}
