using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private Collider[] colliders;

    void Awake()
    {
        Debug.Log("Press 'e' to pick up and 't' to drop objects");
        rb = GetComponent<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }

    public void PickUp(Transform destination)
    {
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        // Disable colliders so the held item doesn't push the player around
        foreach (var c in colliders) c.enabled = false;

        transform.SetParent(destination);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Drop()
    {
        transform.SetParent(null);

        foreach (var c in colliders) c.enabled = true;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(250f,0f,0f);
            rb.useGravity = true;
        }
    }

}
