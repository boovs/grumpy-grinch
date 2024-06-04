using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Class variables
    public GameObject damageEffect;
    private int spikeDamage = 1;
    private float spikeBounce = 10;

    // Function to check for collision between player and spikes
    void OnCollisionEnter2D(Collision2D other) {

        GameObject objectHit = other.gameObject;
        // Player-spike collisions
        if (objectHit.CompareTag("Player"))
        {
            
            PlayerHealth playerHealth = objectHit.GetComponent<PlayerHealth>();
            // Apply damage and show damage animation
            if (playerHealth.playerDead == false)
            {
                playerHealth.TakeDamage(spikeDamage);
                Instantiate(damageEffect, objectHit.transform.position, Quaternion.identity);
                Rigidbody2D playerRB = objectHit.GetComponent<Rigidbody2D>();
                playerRB.velocity = new Vector2(playerRB.velocity.x, spikeBounce);
            }
        }
        // Enemy-spike collisions
        if (objectHit.CompareTag("Enemy"))
        {
            // Apply damage and show damage animation
            Instantiate(damageEffect, objectHit.transform.position, Quaternion.identity);
            EnemyHealth enemyHealth = objectHit.GetComponent<EnemyHealth>();
            enemyHealth.EnemyTakeDamage(spikeDamage);
            Rigidbody2D enemyRB = objectHit.GetComponent<Rigidbody2D>();
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, spikeBounce);
        }
    }
}
