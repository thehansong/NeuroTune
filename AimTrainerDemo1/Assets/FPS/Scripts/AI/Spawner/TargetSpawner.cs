using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab of the target (sphere)
    public float spawnInterval = 0.5f; // Interval between spawns
    public float lifeTime = 1.0f;
    public Vector3 minSpawnCoords = new Vector3(-30.7f, 0.4f, 3.3f); // Area within which to spawn targets
    public Vector3 maxSpawnCoords = new Vector3(-6, 7, 16.7f); // Area within which to spawn targets

    void Start()
    {
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(minSpawnCoords.x, maxSpawnCoords.x),
            Random.Range(minSpawnCoords.y, maxSpawnCoords.y),
            Random.Range(minSpawnCoords.z, maxSpawnCoords.z)
        );

        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);

        // Attach Target script to handle self-destruction
        Target targetScript = target.AddComponent<Target>();
        targetScript.lifetime = lifeTime; // Set lifetime to 2 seconds
    }
}
