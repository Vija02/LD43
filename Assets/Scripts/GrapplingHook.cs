using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    public DistanceJoint2D joint;
    public LineRenderer lineRenderer;

    private bool hooked = false;

    void Update() {
        if (Input.GetKey(KeyCode.V))
        {
            hooked = true;
            GameObject[] hooks = GameObject.FindGameObjectsWithTag("Hook");

            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject gameObject in hooks)
            {
                Transform t = gameObject.transform;
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }

            if (tMin)
            {
                joint.connectedAnchor = tMin.position;
                lineRenderer.SetPositions(new Vector3[] { transform.position, tMin.position });
            }
            else
            {
                hooked = false;
            }
        }
        else
        {
            hooked = false;
        }


        joint.enabled = hooked;
        lineRenderer.enabled = hooked;

    }
}
