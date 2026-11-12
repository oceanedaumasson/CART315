using System.Collections;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int minObjectsToSpawn = 5;
    public int maxObjectsToSpawn = 10;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 2f;
    public float fixedSpawnHeight = 4f;
    
    public float minXPosition = -5f;
    public float maxXPosition = 5f;
    public float minZPosition = -5f;
    public float maxZPosition = 5f;

    void Start()
    {
        StartCoroutine(SpawnObjectsWithDelay());
    }

    IEnumerator SpawnObjectsWithDelay() {
        int numObjectsToSpawn = Random.Range(minObjectsToSpawn, maxObjectsToSpawn + 1);

        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(minXPosition, maxXPosition);
        float randomZ = Random.Range(minZPosition, maxZPosition);
        return new Vector3(randomX, fixedSpawnHeight, randomZ);
    }
}
