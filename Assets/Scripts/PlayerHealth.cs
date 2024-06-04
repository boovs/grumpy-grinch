using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Health script from Can With Code
// Reference: https://www.youtube.com/watch?v=aoZqeG7rqV0
// And also from Night Run Studio
// Reference: https://www.youtube.com/watch?v=KF3EVjOhN4c

public class PlayerHealth : MonoBehaviour
{
    // Player stat variables
    public int maxHealth = 4;
    public int healthPoints;
    public bool playerDead;

    // Death variables
    public GameObject deathEffect;
    public SpriteRenderer playerSprite;
    public PlayerMovement playerMovement;

    // Sound variables
    [SerializeField] private AudioSource playerDamagedSound;
    [SerializeField] private AudioSource playerHealSound;
    [SerializeField] private AudioSource playerDeathSound;

    private void Start() 
    {
        healthPoints = maxHealth;
        playerDead = false;
    }

    // Receive damage function
    public void TakeDamage(int damageReceived)
    {   // Do not apply damage to deleted objects
        if (gameObject != null) 
        {
            healthPoints -= damageReceived;
            if (healthPoints <= 0 && !playerDead) 
            {
                Die();
            }
            // Apply take damage sound
            playerDamagedSound.Play();
        }
    }

    // Healing function
    public void Heal(int healingReceived) 
    {
        if (gameObject != null && !playerDead) 
        {
            // Only heal if max health not exceeded & play heal sound
            if (healthPoints < maxHealth) {
                healthPoints += healingReceived;
            }
            playerHealSound.Play();
        }
        
    }

    // Death function
    public void Die()
    {
        Debug.Log("Player has died.");
        playerDead = true;
        
        // Play blood effect & death sound
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        playerDeathSound.Play();

        // Instead of destroying player object at death, remove from renderer
        playerSprite.enabled = false;
        playerMovement.enabled = false;
    }
}
