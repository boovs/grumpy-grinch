using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced from: https://www.youtube.com/watch?v=s32nWGJ9OjI
public class GoombaStomp : MonoBehaviour
{
    public float bounceY = 12f;
    public int stompDamage = 30;
    private Rigidbody2D playerRB;
    public GameObject deathEffect;

    // Sound variables
    [SerializeField] private AudioSource goombaNoise;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            // Destroy(other.gameObject);
            // Instead of destroying game object, apply some damage
            Instantiate(deathEffect, other.transform.position, Quaternion.identity);
            // Destroy(other.gameObject);

            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.EnemyTakeDamage(stompDamage);
            playerRB.velocity = new Vector2(playerRB.velocity.x, bounceY);
            goombaNoise.Play();
        }
    }

}
