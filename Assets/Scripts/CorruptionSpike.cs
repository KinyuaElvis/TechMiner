// CorruptionSpike.cs
using UnityEngine;

public class CorruptionSpike : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float moveDistance = 5f;
    public float speed = 2f;
    
    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move back and forth along a path
        transform.Translate(moveDirection * direction * speed * Time.deltaTime);
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            direction *= -1; // Reverse direction
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Here you can add a penalty, like slowing the player
            // or making them drop their data.
            // For now, let's just debug.
            Debug.Log("Player hit by Corruption!");
            
            // A simple implementation: make the player drop their data.
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory.IsHoldingData())
            {
                // This is a more advanced step, for now we just destroy it.
                // A better version would "drop" it on the ground.
                inventory.DropData();
            }
        }
    }
}