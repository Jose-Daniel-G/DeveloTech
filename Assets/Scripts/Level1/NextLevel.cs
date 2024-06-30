using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextLevel;

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collided object has the tag "NextLevel"
        if (collider.CompareTag("Player"))
        {
            // Load the next level
            SceneManager.LoadScene(nextLevel);
        }
    }
}
