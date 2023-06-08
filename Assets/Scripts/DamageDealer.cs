using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 1f;
    //public string targetTag;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        BlueHealthManager blueHealthManager = otherObject.GetComponent<BlueHealthManager>();

        if(blueHealthManager != null)
        {
            blueHealthManager.TakeDamage(damageAmount);
        }
    }
}
