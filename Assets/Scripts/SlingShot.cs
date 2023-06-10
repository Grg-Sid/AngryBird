using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] lineRenderer;
    public Transform[] stripPosition;
    public Transform center;
    public Transform idlePosition;

    bool isMouseDown;


    void Start()
    {
        lineRenderer[0].positionCount = 2;
        lineRenderer[1].positionCount = 2;
        lineRenderer[0].SetPosition(0, stripPosition[0].position);
        lineRenderer[1].SetPosition(0, stripPosition[1].position);
    }


    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 15;

            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetStrips(mousePosition);
        }
        else
        {
            ResetStrip();
        }
    }

    void ResetStrip()
    {
        SetStrips(idlePosition.position);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderer[0].SetPosition(1, position);
        lineRenderer[1].SetPosition(1, position);
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }
    private void OnMouseUp() 
    { 
        isMouseDown = false;
    }
}

