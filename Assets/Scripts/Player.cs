using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D pivot;

    public float releaseTime = 0.15f;
    public float dragDistance = 2f;

    private bool isDragging = false;


    private void Update()
    {
        if (isDragging)
        {
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(currentPosition, pivot.position) > dragDistance)
            {
                rb.position = pivot.position + (currentPosition - pivot.position).normalized * dragDistance;    
            }
            else
            {
                rb.position = currentPosition;
            }
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
