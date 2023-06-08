using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))] 
public class LineTrajectory : MonoBehaviour
{
    public LineRenderer lr;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;
        //Vector3[] points = new Vector3[lr.positionCount];
        //points[0] = startPoint;
        //points[1] = endPoint;
        lr.SetPosition(0, startPoint);
        lr.SetPosition(1, endPoint);
        lr.enabled = true;
    }

    public void EndLine()
    {
        lr.positionCount = 0;
        lr.enabled= false;
    }
}
