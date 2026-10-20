using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    
    public bool Occupies(int x, int y)
    {
        Bounds b = collider.bounds;
        return b.Contains(new Vector3(x, y, b.center.z));
    }
}
