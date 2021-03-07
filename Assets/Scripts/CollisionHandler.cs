using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;

    private AudioSource audioSource;
    private bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
        {
            return;
        }

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
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(LoadNextLevel), loadDelay);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);
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
