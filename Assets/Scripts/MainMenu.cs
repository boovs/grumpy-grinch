using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play button logic to load first level
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Maybe add a settings button

    // Quit button logic to exit game
    public void QuitGame() 
    {
        Application.Quit();
    }
}
