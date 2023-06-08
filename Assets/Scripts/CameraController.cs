using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject birds;
    public float offsetX;
    public float offsetY;
    public float offsetSmoothing;
    private Vector3 birdPosition;


    
    void Start()
    {
        
    }
    void Update()
    {
        birdPosition = new Vector3(birds.transform.position.x, birds.transform.position.y, transform.position.z);
        
        if(birds.transform.localScale.x > 0f)
        {
            birdPosition = new Vector3(birdPosition.x + offsetX, birdPosition.y + offsetY, birdPosition.z);    
        }
        else
        {
            birdPosition = new Vector3(birdPosition.x - offsetX, birdPosition.y + offsetY, birdPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, birdPosition, offsetSmoothing * Time.deltaTime);
    }
}
