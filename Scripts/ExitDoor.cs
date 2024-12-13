using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] AudioClip openingDoorSFX, closingDoorSFX; // The sound effect to play
    [SerializeField] float secondsToLoad = 2f; // Delay before loading the next level

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger the door open animation
        GetComponent<Animator>().SetTrigger("Open");
        PlayOpeningDoorSFX(); // Play the opening door sound effect
    }

    public void StartLoadingNextLevel()
    {
        // Trigger the door close animation
        GetComponent<Animator>().SetTrigger("Close");
        AudioSource.PlayClipAtPoint(closingDoorSFX, Camera.main.transform.position);
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(secondsToLoad);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var totalScenes = SceneManager.sceneCountInBuildSettings;

        // Load the next scene or loop back to Level 1
        if (currentSceneIndex + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("Level 1"); // Replace with your Level 1 scene name
        }
    }

    void PlayOpeningDoorSFX()
    {
        // Play the sound effect at the door's position
        if (openingDoorSFX != null)
        {
            AudioSource.PlayClipAtPoint(openingDoorSFX, Camera.main.transform.position);
        }
    }
}
