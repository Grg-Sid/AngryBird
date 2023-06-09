using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float hitPoint = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 4)
        {
            hitPoint -= collision.relativeVelocity.magnitude;
            //Debug.Log(collision.relativeVelocity.magnitude);
        }    

    }

    private void Update()
    {
        if(gameObject.tag == "Bird")
        {
            hitPoint -= 0.05f;
        }
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}
