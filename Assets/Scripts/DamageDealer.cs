using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 1f;
    //public string targetTag;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        HealthManager healthManager = otherObject.GetComponent<HealthManager>();

        if(healthManager != null)
        {
            healthManager.TakeDamage(damageAmount);
        }
    }
}
