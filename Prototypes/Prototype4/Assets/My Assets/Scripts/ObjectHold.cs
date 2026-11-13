using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectHold : MonoBehaviour
{
    public Transform hand; // An object representing the location where the player holds items
    public Camera playerCamera;
    public float reachDistance = 4f; // Interaction distance
    private Target currentItem; // Link to the current item being picked up

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryPickup();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            PutDown();
        }
    }

    void TryPickup()
    {
        // Check if the item is already holding
        if (currentItem != null)
        {
            Debug.Log("You already have the item in your hands.");
            return;
        }

        // Checking if there is a hand object
        if (hand == null)
        {
            Debug.LogError("Hand object is not assigned.");
            return;
        }

        // Create a beam forward from the player
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Checking if the beam hits something
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            // Checking if an object has a PickupableItem component
            Target item = hit.collider.GetComponentInParent<Target>();
            if (item != null)
            {
                // Calling the method for picking up an object
                item.PickUp(hand);
                currentItem = item;
            }
        }
    }

    void PutDown()
    {
        if (currentItem == null)
        {
            Debug.Log("Nothing to put down");
            return;
        }

        currentItem.Drop();
        currentItem = null;
    }
}