using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Item drop guide from Night Run Studio
// Reference: https://www.youtube.com/watch?v=Ud0Qqo5ytkI

public class ItemDrop : MonoBehaviour
{

    private Rigidbody2D itemRB;
    public GameObject presentEffect;
    public float dropForce = 5;
    public int healAmount = 1;


    // Start is called before the first frame update
    void Start()
    {
        itemRB = GetComponent<Rigidbody2D>();
        itemRB.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When present collides with player
    private void OnCollisionEnter2D(Collision2D other)
    {
        // If enemy collided with player
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            // Heal player for now
            playerHealth.Heal(healAmount);
            // Tally up points

            // Play small particle effect
            Instantiate(presentEffect, transform.position, Quaternion.identity);
            // Remove present from scene
            Destroy(gameObject);
        }
    }


}
