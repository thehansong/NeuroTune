using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner Instance { get; private set; }

    [Header("Target Settings")]
    public GameObject targetPrefab;                                     // Prefab of the target (sphere)
    public float lifeTime = 3.0f;                                       // Lifetime of the target in seconds
    public Vector3 minSpawnCoords = new Vector3(-30.7f, 0.4f, 3.3f);    // Minimum spawn coordinates
    public Vector3 maxSpawnCoords = new Vector3(-6, 7, 16.7f);          // Maximum spawn coordinates
    public Vector2 minmaxScale = new Vector2(0.1f, 1.0f);               // Minimum and maximum scale for the targets

    [Header("Spawn Settings")]
    [SerializeField]
    private float spawnInterval = 2.0f;                                 // Init spawn interval between spawns
    public float minSpawnInterval = 0.2f;                               // Minimum interval between spawns
    public float maxSpawnInterval = 4.0f;                               // Maximum interval between spawns

    [Header("Difficulty Settings")]
    public float difficultyAdjustmentInterval = 3.0f;                   // Time interval to adjust difficulty
    private float lastDifficultyAdjustmentTime = 0;
    private float currentDifficulty = 1.0f;                             // Initial difficulty level

    [Header("Fitts' Law Constants")]
    public float a = 0.2f;
    public float b = 0.1f;
    public float sizeAdditionFactor = 1f;

    private int hits = 0;
    private int misses = 0;
    private Coroutine spawnCoroutine;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(minSpawnCoords.x, maxSpawnCoords.x),
                Random.Range(minSpawnCoords.y, maxSpawnCoords.y),
                Random.Range(minSpawnCoords.z, maxSpawnCoords.z)
            );

            float distance = Vector3.Distance(spawnPosition, Vector3.zero); // player @zerozero
            float targetWidth = CalculateTargetWidth(distance);

            GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
            target.transform.localScale = new Vector3(targetWidth, targetWidth, targetWidth);

            // Log the size of the spawned target
            Debug.Log("Spawned Target Size: " + targetWidth);

            // Attach Target script to handle self-destruction
            Target targetScript = target.AddComponent<Target>();
            targetScript.lifetime = lifeTime;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void HitByPlayer()
    {
        hits++;
        Debug.Log("Hit count by player: " + hits);
        AdjustDifficulty();
    }

    public void Hit()
    {
        hits++;
        Debug.Log("Hit Count: " + hits);
        AdjustDifficulty();
    }

    public void Miss()
    {
        misses++;
        Debug.Log("Miss Count: " + misses);
        AdjustDifficulty();
    }

    private void AdjustDifficulty()
    {
        if (Time.time - lastDifficultyAdjustmentTime < difficultyAdjustmentInterval)
        {
            return;
        }

        lastDifficultyAdjustmentTime = Time.time;

        float accuracy = (float)hits / (hits + misses);
        Debug.Log("Accuracy: " + accuracy);

        float oldSpawnInterval = spawnInterval; // Save the old spawn interval for comparison

        if (accuracy > 0.8f)
        {
            currentDifficulty += 0.1f; // Increase difficulty
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 0.1f); // Decrease spawn interval
            Debug.Log("Increased Difficulty: " + currentDifficulty + " | Accuracy: " + accuracy);
        }
        else if (accuracy < 0.5f)
        {
            currentDifficulty = Mathf.Max(0.1f, currentDifficulty - 0.1f); // Decrease difficulty
            spawnInterval = Mathf.Min(maxSpawnInterval, spawnInterval + 0.1f); // Increase spawn interval
            Debug.Log("Decreased Difficulty: " + currentDifficulty + " | Accuracy: " + accuracy);
        }
        else
        {
            Debug.Log("Difficulty Unchanged: " + currentDifficulty + " | Accuracy: " + accuracy);
        }

        Debug.Log("Adjusted Difficulty: " + currentDifficulty);
        Debug.Log("Spawn Interval changed from " + oldSpawnInterval + " to " + spawnInterval);

        hits = 0;
        misses = 0;

        // Restart the spawn coroutine with the updated spawn interval
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        spawnCoroutine = StartCoroutine(SpawnTarget());
    }

    private float CalculateTargetWidth(float distance)
    {
        // Fitts' Law to calculate target width and apply addition factor
        float index = (currentDifficulty - a) / b;
        float targetWidth = sizeAdditionFactor + (2 * distance / Mathf.Pow(2, index));

        // Debug information
        Debug.Log("Distance: " + distance);
        Debug.Log("Index: " + index);
        Debug.Log("Unclamped Target Width: " + targetWidth);

        targetWidth = Mathf.Clamp(targetWidth, minmaxScale.x, minmaxScale.y); // Clamp target width to the defined range

        Debug.Log("Clamped Target Width: " + targetWidth); // Log the calculated width for debugging
        return targetWidth;
    }
}
