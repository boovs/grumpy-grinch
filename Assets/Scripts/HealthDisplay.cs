using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Reference: https://www.youtube.com/watch?v=uqGkNTFzYXM
public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;
    
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    // Allow this script to communicate with player health script
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Get PlayerHealth script values
            maxHealth = playerHealth.maxHealth;
            health = playerHealth.healthPoints;

            // Check health and modify hearts based on it
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth) 
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
    }
}
