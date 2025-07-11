// GameManager.cs

using UnityEngine;

public class GameManager : MonoBehaviour
{
    // --- All public Text variables have been removed ---

    private DataPacket.DataType requiredData;
    private int score = 0;
    public float levelTime = 60f;
    private float currentTime;
    private bool isGameOver = false;

    void Start()
    {
        currentTime = levelTime;
        isGameOver = false;
        Time.timeScale = 1; // Ensure the game is running
        
        // Announce the start of the game to the console
        Debug.Log("--- Game Start ---");
        
        GenerateNewInstruction();
        UpdateScore(0); // Log the starting score
    }

    void Update()
    {
        // Don't do anything if the game is over
        if (isGameOver) return;
        
        // Update timer
        currentTime -= Time.deltaTime;
        
        // We can still log the time, but maybe not every single frame
        // to avoid spamming the console. We can use a small timer for this.
        // For simplicity in this example, we'll leave it out. Feel free to add it back!
        // Debug.Log($"Time: {currentTime:F1}");

        if (currentTime <= 0)
        {
            // Game Over logic
            currentTime = 0;
            isGameOver = true;
            Time.timeScale = 0; // Freeze game
            
            // Log a prominent Game Over message to the console
            Debug.LogWarning("--- GAME OVER ---");
            Debug.LogWarning($"Final Score: {score}");
        }
    }

    void GenerateNewInstruction()
    {
        // Randomly pick a new data type to fetch
        int randomType = Random.Range(0, 3); // 0=Red, 1=Green, 2=Blue
        requiredData = (DataPacket.DataType)randomType;
        
        // Log the new instruction to the console
        Debug.Log($"NEW INSTRUCTION: Fetch {requiredData.ToString().ToUpper()} DATA");
    }

    public void DataDelivered(DataPacket.DataType deliveredType)
    {
        if (isGameOver) return; // Don't process deliveries after game over

        if (deliveredType == requiredData)
        {
            // Correct delivery!
            Debug.Log("Correct Data Delivered! (+100 Points, +5s Time)");
            UpdateScore(100);
            currentTime += 5f; // Give a time bonus!
            GenerateNewInstruction();
        }
        else
        {
            // Wrong delivery!
            Debug.LogWarning("Wrong Data Delivered! (-50 Points)");
            UpdateScore(-50);
        }
    }
    
    // A single function to handle score changes and log them
    void UpdateScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
    }
}