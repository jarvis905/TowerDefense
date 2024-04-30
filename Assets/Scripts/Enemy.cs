using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // References
    public Transform trans; // Reference to the enemy's transform
    public Transform projectileSeekPoint; // Reference to the point from which the enemy seeks projectiles

    // Stats
    public float maxHealth; // Maximum health of the enemy

    public float healthGainPerLevel;

    [HideInInspector] public float health; // Current health of the enemy, hidden in the inspector
    
    [HideInInspector] public bool alive = true; // Indicates whether the enemy is alive

    // Methods:

    // Method to make the enemy take damage
    public void TakeDamage(float amount)
    {
        // Only proceed if damage taken is more than 0
        if (amount > 0)
        {
            // Reduce health by 'amount' but don't go under 0
            health = Mathf.Max(health - amount, 0);

            // If all health is lost
            if (health == 0)
            {
                // Call Die
                Die();
            }
        }
    }

    // Method to make the enemy die
    public void Die()
    {
        // If the enemy is alive
        if (alive)
        {
            alive = false; // Set alive flag to false
            Destroy(gameObject); // Destroy the enemy GameObject
        }
    }

    public void Leak()
    {
        Player.remainingLives -= 1;
        Destroy(gameObject);
    }

    // Unity events:

    // Start is called before the first frame update
    protected virtual void Start()
    {
        maxHealth += healthGainPerLevel * (Player.level - 1);
        health = maxHealth; // Set the initial health to the maximum health
    }

    // Update is called once per frame
    void Update()
    {

    }
}
