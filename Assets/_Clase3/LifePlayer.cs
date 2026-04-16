using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    public int health = 100; // vida del jugador

    void Update()
    {
    }
    
    // LIFE AND DIE
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}