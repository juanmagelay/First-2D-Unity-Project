using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce la salud con el daño, pero el mínimo es 0
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log("Vida actual: " + currentHealth + "Daño recibido: " + damage );
    }

    public void Heal(float life)
    {
        // Aumenta la salud con la curación, pero el máximo es 100
        currentHealth = Mathf.Min(currentHealth + life, maxHealth);
        Debug.Log("Vida actual: " + currentHealth + "Vida recuperada: " + life );
    }
}
