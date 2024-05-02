using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;  // Initial health of the player

    // Method to be called by other scripts to apply damage to the player
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Player now has {health} health.");

        if (health <= 0)
        {
            Die();  // Handle player death
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        // Here you can add logic for what happens when the player dies, e.g., restart the level, show a death screen, etc.
        // This can be handled through a game manager or similar system.
    }
}
