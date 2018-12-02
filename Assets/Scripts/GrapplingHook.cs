using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

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

            GameObject[] hooksOnScreen = hooks.Where(x => gameObjectInCamera(x)).ToArray();

            GameObject[] hooksAboveCharacter = hooksOnScreen.Where(x => x.transform.position.y > transform.position.y).ToArray();

            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject gameObject in hooksAboveCharacter)
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

    public bool gameObjectInCamera(GameObject gj)
    {
        Vector3 pos = gj.transform.position;

        Vector3 cameraPosition = Camera.main.transform.position;
        float orthographicSize = Camera.main.orthographicSize;

        if (pos.x < cameraPosition.x + orthographicSize && pos.x > cameraPosition.x - orthographicSize)
        {
            if(pos.y < cameraPosition.y + orthographicSize && pos.y > cameraPosition.y - orthographicSize)
            {
                return true;
            }
        }
        return false;
    }
}
