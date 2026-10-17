using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    private Snake snake;
    
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

        // Pick a random position inside the bounds
        // Round the values to ensure it aligns with the grid
        int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));

        // Prevent the food from spawning on the snake
        while (snake.Occupies(x, y))
        {
            x++;

            if (x > bounds.max.x)
            {
                x = Mathf.RoundToInt(bounds.min.x);
                y++;

                if (y > bounds.max.y) {
                    y = Mathf.RoundToInt(bounds.min.y);
                }
            }
        }

        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
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
            
            yield return new WaitForSeconds((ShortestSteps() + 1.5f) * secondsPerStep);
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
