using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // Public variables
    [HideInInspector] public float damage; // Damage inflicted by the projectile
    [HideInInspector] public float speed; // Speed of the projectile
    [HideInInspector] public Enemy targetEnemy; // Target enemy of the projectile
    
    public AudioClip firingSoundClip; // Audio file for projectile firing sound

    // Method to set up the projectile
    public void Setup(float damage, float speed, Enemy targetEnemy)
    {
        // Set the damage, speed, and target enemy
        this.damage = damage;
        this.speed = speed;
        this.targetEnemy = targetEnemy;

        // Call the OnSetup method
        OnSetup();
    }

    // Abstract method to be implemented by subclasses
    protected abstract void OnSetup();
}
