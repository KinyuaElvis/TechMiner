using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // This is the name of the scene you want to load.
    // Making it a public string allows you to change the scene name directly
    // in the Unity Inspector without editing the code.
    public string sceneToLoad = "Playground";

    /// <summary>
    /// This public method will be called when the user clicks the UI Button.
    /// It must be public to be accessible from the Button's OnClick event in the Inspector.
    /// </summary>
    public void LoadGameScene()
    {
        // Check if the scene name is not empty to avoid errors.
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Logs a message to the console for debugging purposes.
            Debug.Log("Loading scene.... " + sceneToLoad);

            // The core function that loads the new scene.
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            // Logs an error if the scene name was not set in the Inspector.
            Debug.LogError("Scene to load is not set in the Inspector!");
        }
    }
}