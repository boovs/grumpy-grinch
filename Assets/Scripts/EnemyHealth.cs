using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some enemy code from Brackeys
// Reference: https://www.youtube.com/watch?v=wkKsl1Mfp5M&t=200s
// Some collision damage code from: Night Run Studio
// Reference: https://www.youtube.com/watch?v=_1Oou4459Us

public class EnemyHealth : MonoBehaviour
{
    // Enemy stat variables
    public int enemyHealth = 15;

    // Enemy on death variables
    public GameObject deathEffect;
    public GameObject[] itemDrops;
    private Vector3 spawnOffset = new Vector3(0, 2, 0);

    // Register damage on enemy and call death function when health runs out
    public void EnemyTakeDamage(int damageReceived)
    {   // Do not apply damage to deleted objects
        if (gameObject != null) 
        {   
            enemyHealth -= damageReceived;
            if (enemyHealth <= 0)
            {
                EnemyDie();
            }
        }
    }

    // Item drop handler
    private void ItemDrop() 
    {
        // For each item in item drops list, drop it
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], (transform.position + spawnOffset), transform.rotation);
        }
    }

    // Function to play death animation and remove enemy from scene
    void EnemyDie()
    {
        // Play death animation, drop item, and remove object
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        ItemDrop();
        Destroy(gameObject);
    }

}
