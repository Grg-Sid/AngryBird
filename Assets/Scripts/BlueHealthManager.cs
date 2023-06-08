using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHealthManager : MonoBehaviour
{
    public float healthPoint;
    public float maxHealth;
    void Start()
    {
        healthPoint = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if(healthPoint <= 0)
        {
            Destroy(gameObject);    
        }
    }
}
