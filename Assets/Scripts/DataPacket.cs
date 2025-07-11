// DataPacket.cs
using UnityEngine;

public class DataPacket : MonoBehaviour
{
    // We can use an enum to define different types of data.
    public enum DataType { Red, Green, Blue }
    public DataType type;

    // Optional: Add a nice bobbing effect to make it look alive.
    private Vector3 startPosition;
    public float bobHeight = 0.25f;
    public float bobSpeed = 2f;

    void Start()
    {
        startPosition = transform.position;
        SetColor();
    }

    void Update()
    {
        // Simple bobbing animation
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    
    // Set the material color based on the data type
    void SetColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        switch (type)
        {
            case DataType.Red:
                renderer.material.color = Color.red;
                renderer.material.SetColor("_EmissionColor", Color.red);
                break;
            case DataType.Green:
                renderer.material.color = Color.green;
                renderer.material.SetColor("_EmissionColor", Color.green);
                break;
            case DataType.Blue:
                renderer.material.color = Color.blue;
                renderer.material.SetColor("_EmissionColor", Color.blue);
                break;
        }
    }
}