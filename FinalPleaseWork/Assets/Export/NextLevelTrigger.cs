using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextLevelName; // Name of the next level scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure only the player can trigger the level load
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
