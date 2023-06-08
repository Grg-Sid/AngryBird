using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float releaseTime = 0.15f;

    private bool isDragging = false;


    private void Update()
    {
        if (isDragging)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void OnMouseDown ()
    {
        isDragging = true;
        rb.isKinematic = transform;
    }

    private void OnMouseUp() 
    { 
        isDragging = false;
        rb.isKinematic = false;

        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }

}
