using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;  // Maximum health of the enemy
    private float currentHealth;    // Current health of the enemy

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;  // Initialize health
    }

    // Method to apply damage to the enemy
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;    // Reduce health by the amount of damage taken
        Debug.Log("Enemy took damage: " + amount + ", Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();                  // Call the Die method if health goes below zero
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);        // Destroys the enemy GameObject from the scene
    }
}
