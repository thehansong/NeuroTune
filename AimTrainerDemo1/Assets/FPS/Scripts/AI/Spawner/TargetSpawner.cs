using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab of the target (sphere)
    public float spawnInterval = 2f; // Interval between spawns
    public Vector3 spawnArea = new Vector3(10, 5, 10); // Area within which to spawn targets

    void Start()
    {
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);

        // Attach Target script to handle self-destruction
        Target targetScript = target.AddComponent<Target>();
        targetScript.lifetime = 2f; // Set lifetime to 2 seconds
    }
}
