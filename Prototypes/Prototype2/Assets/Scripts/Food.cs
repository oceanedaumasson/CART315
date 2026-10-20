using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    private Snake snake;
    public float extraStep = 1.5f;
    
    private Coroutine spawnCoroutine;
    
    private void Awake()
    {
        snake = FindFirstObjectByType<Snake>();
    }

    private void Start()
    {
        RandomizePosition();
        spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        Obstacle[] obstacles = FindObjectsByType<Obstacle>(FindObjectsSortMode.None);

        for (int i = 0; i < 200; i++)
        {
            int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));
            int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));

            if (IsFree(x, y, obstacles))
            {
                transform.position = new Vector2(x, y);
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                return;
            }
        }
    }

    // Makes sure not to spawn on player or obstacles
    private bool IsFree(int x, int y, Obstacle[] obstacles)
    {
        if (snake.Occupies(x, y))
            return false;
        
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle.Occupies(x, y))
                return false;
        }

        return true;
    }

    /**public void OnReached()
    {
        StopCoroutine(SpawnCoroutine());
        RandomizePosition();
        spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }*/
    
    // Randomize apple location based on shortest path and snake speed
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float secondsPerStep = 1f / (snake.speed * snake.speedMultiplier);
            
            yield return new WaitForSeconds((ShortestSteps() + extraStep) * secondsPerStep);
            RandomizePosition();
        }
    }
    
    // Find shortest path from player to apple
    private int ShortestSteps()
    {
        Vector2Int player = new Vector2Int(
            Mathf.RoundToInt(snake.transform.position.x),
            Mathf.RoundToInt(snake.transform.position.y));
        Vector2Int apple = new Vector2Int(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y));

        Vector2Int delta = apple - player;
        int steps = Mathf.Abs(delta.x) + Mathf.Abs(delta.y);

        return steps;
    }
}
