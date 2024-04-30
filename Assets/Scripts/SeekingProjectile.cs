using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingProjectile : Projectile
{
    // References
    [Header("References")]
    public Transform trans; // Reference to the projectile's transform

    // Private variables
    private Vector3 targetPosition; // Position of the target enemy

    // Methods

    // Called when the projectile is set up
    protected override void OnSetup()
    {
        // Attaching an audio source to each instance of Cannon
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = firingSoundClip;
        audioSource.Play();
    }

    // Unity events

    // Called once per frame
    void Update()
    {
        if (targetEnemy != null)
        {
            // Mark the enemy's last position
            targetPosition = targetEnemy.projectileSeekPoint.position;
        }

        // Point towards the target position
        trans.forward = (targetPosition - trans.position).normalized;

        // Move towards the target position
        trans.position = Vector3.MoveTowards(trans.position, targetPosition, speed * Time.deltaTime);

        // If we have reached the target position
        if (trans.position == targetPosition)
        {
            // Damage the enemy if it's still around
            if (targetEnemy != null)
                targetEnemy.TakeDamage(damage);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
