using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform starPos;
    private float line_width = 0.12f;
    public clawMovement clawMovement;
    private void Awake()
    {
        clawMovement = FindObjectOfType<clawMovement>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = line_width;
        lineRenderer.enabled = false;
    }
    public void RenderLine(Vector3 endRenderPos,bool enableRen)
    {
        if (enableRen)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled )
            {
                lineRenderer.enabled = false;
            }
        }
        if (lineRenderer.enabled == true)
        {
            Vector3 temp= starPos.position;
            temp.z = -10;

            starPos.position = temp;
            temp = endRenderPos;
            temp.z = 0;
            endRenderPos = temp;

            lineRenderer.SetPosition(0, starPos.position);
            lineRenderer.SetPosition(1, endRenderPos);
        }
    }
}
