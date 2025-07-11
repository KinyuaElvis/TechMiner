using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelLoader : MonoBehaviour
{
    // This method is called by Unity's physics engine automatically
    // when this GameObject's collider enters another collider marked as a "Trigger".
    private void OnTriggerEnter(Collider other)
    {
        // We use CompareTag for performance; it's faster than checking other.gameObject.name.
        
        // Check if the object we collided with has the tag "LevelOne"
        if (other.CompareTag("LevelOne"))
        {
            Debug.Log("Collided with LevelOne trigger. Loading scene: LevelOne");
            // Load the scene named "LevelOne"
            SceneManager.LoadScene("LevelOne");
        }
        // Check if the object we collided with has the tag "LevelTwo"
        else if (other.CompareTag("LevelTwo"))
        {
            Debug.Log("Collided with LevelTwo trigger. Loading scene: LevelTwo");
            // Load the scene named "LevelTwo"
            SceneManager.LoadScene("LevelTwo");
        }
    }

    // --- OPTIONAL: For Physical Collisions ---
    // Uncomment this method if your cubes are solid (Is Trigger is OFF)
    // and you want to load the level when the player physically bumps into them.
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LevelOne"))
        {
            Debug.Log("Collided with LevelOne object. Loading scene: LevelOne");
            SceneManager.LoadScene("LevelOne");
        }
        else if (collision.gameObject.CompareTag("LevelTwo"))
        {
            Debug.Log("Collided with LevelTwo object. Loading scene: LevelTwo");
            SceneManager.LoadScene("LevelTwo");
        }
    }
    */
}