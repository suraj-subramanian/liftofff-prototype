using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    public float loadDelay = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Fuel":
                Debug.Log("Fuel");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Respawn":
                Debug.Log("Respawn");
                break;
            default:
                StartCrashSequence();
                break;
        }

    }

    private void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(LoadNextLevel), loadDelay);
    }

    private void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(ReloadLevel), loadDelay);
    }
    private void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        if(nextLevelIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
}
