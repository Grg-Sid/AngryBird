using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float hitPoint = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 6)
        {
            hitPoint -= collision.relativeVelocity.magnitude;
        }    

    }

    private void FixedUpdate()
    {
        if(gameObject.tag == "Bird")
        {
            hitPoint -= 0.1f;
        }
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}
