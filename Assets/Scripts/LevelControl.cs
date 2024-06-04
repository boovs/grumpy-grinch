using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


// Unity guide on switching levels by Dual Core Studio
// Reference: https://www.youtube.com/watch?v=26d1uZ7yrfY

public class LevelControl : MonoBehaviour
{
    // Get active scene
    private Scene activeScene;
    private string activeSceneName;

    private void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        activeSceneName = activeScene.name;
    }

    // When player collides with door, change scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If on level 1, go to level 2
            if (activeSceneName == "Level1")
            {
                // Load level with scene name
                SceneManager.LoadScene("Level2");
            }

            // If on level 2, go to credits scene
        }
    }
}
