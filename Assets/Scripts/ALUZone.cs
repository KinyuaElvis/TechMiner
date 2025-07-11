// ALUZone.cs
using UnityEngine;

public class ALUZone : MonoBehaviour
{

    public int storedPackets = 0;
    public int packetsNeeded = 5;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.dataPackets > 0)
            {
                storedPackets += player.dataPackets;
                player.dataPackets = 0;
                Debug.Log("Stored packets: " + storedPackets);
                
                if (storedPackets >= packetsNeeded)
                {
                    Debug.Log("Level Complete!");
                    // Add level complete logic here
                }
            }
        }
    }

//     // This will connect to our main game controller
//     private GameManager gameManager;
//     public ParticleSystem successParticles; // Assign a particle system in the Inspector

//     void Start()
//     {
//         // Find the GameManager in the scene
//         gameManager = FindObjectOfType<GameManager>();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         // Check if the object that entered is the player
//         if (other.CompareTag("Player"))
//         {
//             // The player has entered the zone, now check if they are holding data
//             PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
//             if (playerInventory != null && playerInventory.IsHoldingData())
//             {
//                 // Tell the game manager the player delivered data
//                 gameManager.DataDelivered(playerInventory.GetHeldDataType());
                
//                 // Clear the player's inventory
//                 playerInventory.DropData();
                
//                 // Play a success effect!
//                 if (successParticles != null)
//                 {
//                     successParticles.Play();
//                 }
//             }
//         }
//     }
    }