using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Reference: https://www.youtube.com/watch?v=KF3EVjOhN4c
public class EnemyDamage : MonoBehaviour
{
    // Damage-related variables
    public int enemyDamage = 1;
    private PlayerHealth playerHealth;

    // Knockback-related variables
    private PlayerMovement playerMovement;
    private Rigidbody2D playerRB;
    private Rigidbody2D enemyRB;
    public float knockbackForce = 2f;
    
    public UnityEvent OnBegin, OnDone;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // If enemy collided with player
        if (other.gameObject.tag == "Player")
        {
            // Get player's components
            playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            // Deal dmg to player
            playerHealth.TakeDamage(enemyDamage);     

            // Alert that player is getting knocked back by resetting the timer of knock up duration
            playerMovement.knockTimer = playerMovement.knockTotalTime;
            // Alert hat enemy is getting knocked back by resetting the timer of the enemy's knock up duration

            // Get knockback force between enemy and player
            Vector2 difference = (transform.position - other.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            
            // Apply knockback to enemy and player
            playerRB.AddForce(-2*force, ForceMode2D.Impulse);
            enemyRB.AddForce(force, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange

        }
    }

}
