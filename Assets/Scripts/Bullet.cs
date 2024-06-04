using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet script from Brackey
// Reference: https://www.youtube.com/watch?v=wkKsl1Mfp5M&t=200s
public class Bullet : MonoBehaviour
{
    // Bullet properties
    public float ySpeed = 2f;
    public float xSpeed = 10f;
    public int bulletDmg = 15;
    public GameObject impactEffect;
    private Rigidbody2D rb;

    // Sound variables
    // [SerializeField] private AudioSource snowballCollisionSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (xSpeed * transform.right) + (ySpeed * transform.up);
    }

    // Function occurs on bullet collision
    void OnTriggerEnter2D(Collider2D other)
    {
        // Log what bullet hit
        Debug.Log(other.name);

        // Deal damage to enemy if enemy hit
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.EnemyTakeDamage(bulletDmg);

        }

        // Show a snow explosion at the collision point
        Instantiate(impactEffect, transform.position, transform.rotation);
        // Remove bullet from scene after a collision
        Destroy(gameObject);
    }  
}
