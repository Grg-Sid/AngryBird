using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private Rigidbody2D pivot;

    public float releaseTime = 0.15f;
    public float maxDragDistance = 2.5f;
    public float power = 1f;

    private bool isDragging = false;
    private bool isSpecialAbilityActivated = false;

    private Vector2 initialPosition;

    private void Awake()
    {
        pivot = rb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isSpecialAbilityActivated && isDragging)
        {
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pivotPosition = pivot.position;
            Vector2 dragDirection = currentPosition - pivotPosition;

            float dragMagnitude = dragDirection.magnitude;
            float clampedMagnitude = Mathf.Clamp(dragMagnitude, 0f, maxDragDistance);

            Vector2 limitedDirection = dragDirection.normalized * clampedMagnitude;
            currentPosition = pivotPosition + limitedDirection;

            rb.MovePosition(currentPosition);
        }
        else if (isSpecialAbilityActivated && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 force = new Vector2(power, power);
            rb.AddForce(force, ForceMode2D.Impulse);
            Debug.Log("Special Ability");
            isSpecialAbilityActivated = false;
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        rb.isKinematic = true;
        GetComponent<TrailRenderer>().enabled = false;
        initialPosition = rb.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = false;
        if (!isSpecialAbilityActivated)
        {
            StartCoroutine(Launch());
        }
    }

    public IEnumerator Launch()
    {
        isSpecialAbilityActivated = true;
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        GetComponent<TrailRenderer>().enabled = true;
    }
}
