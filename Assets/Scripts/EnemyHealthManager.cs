using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float health = 10f;
    public static int enemyCount = 0;

    private void Start()
    {
        enemyCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > 2f) 
        {
            health -= collision.relativeVelocity.magnitude;
            if(health <= 0)
            { 
                Death();
                enemyCount--;
                Debug.Log(enemyCount);
                if (enemyCount <= 0)
                {
                    Debug.Log("GAME WON!!");
                }
            }
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
