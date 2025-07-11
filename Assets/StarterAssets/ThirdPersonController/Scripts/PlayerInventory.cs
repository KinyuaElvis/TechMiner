// PlayerInventory.cs
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private DataPacket heldDataPacket = null;
    public Transform holdPosition; // An empty GameObject in front of the player

    void OnTriggerEnter(Collider other)
    {
        // Check if we are not holding anything and the other object is a DataPacket
        if (heldDataPacket == null && other.CompareTag("DataPacket"))
        {
            PickupData(other.GetComponent<DataPacket>());
        }
    }

    void PickupData(DataPacket packet)
    {
        heldDataPacket = packet;

        // Make the packet a child of the player's hold position
        // and disable its physics/trigger behavior while held.
        packet.transform.SetParent(holdPosition);
        packet.transform.localPosition = Vector3.zero;
        packet.GetComponent<Collider>().enabled = false;
    }

    public void DropData()
    {
        if (heldDataPacket != null)
        {
            // Destroy the data packet once delivered
            Destroy(heldDataPacket.gameObject);
            heldDataPacket = null;
        }
    }

    public bool IsHoldingData()
    {
        return heldDataPacket != null;
    }

    public DataPacket.DataType GetHeldDataType()
    {
        return heldDataPacket.type;
    }
}