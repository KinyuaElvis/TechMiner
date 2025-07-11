using UnityEngine;
using UnityEngine.SceneManagement; // IMPORTANT: You need this to work with scenes!

public class FinishZone : MonoBehaviour
{
    // This function is called by Unity automatically when another collider
    // with a Rigidbody enters this trigger.
    private void OnTriggerEnter(Collider other)
    {
        // We check if the object that entered has the "Player" tag.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the finish zone. Loading Lobby...");

            // The magic line that loads your lobby scene.
            // Make sure the scene name matches exactly what you have in Build Settings.
            SceneManager.LoadScene("Playground");
        }
    }
}