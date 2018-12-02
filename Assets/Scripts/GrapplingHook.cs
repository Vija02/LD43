using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    public bool enableGrapplingHook = false;

    public DistanceJoint2D joint;
    public LineRenderer lineRenderer;

    public string buttonName = "Use Item";

    private bool hooked = false;

    void Update() {
        if (Input.GetButton(buttonName) && enableGrapplingHook)
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
