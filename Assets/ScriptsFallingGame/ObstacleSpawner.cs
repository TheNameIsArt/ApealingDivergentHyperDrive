using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // The obstacle prefab
    public float spawnInterval = 2f;  // Time interval between spawning obstacles
    public float spawnHeight = -6f;   // The y position where obstacles spawn (below the screen)
    public float spawnWidth = 5f;     // The horizontal range where obstacles can spawn
    public float obstacleSpeed = 5f; // Speed at which obstacles move upward

    void Start()
    {
        // Check if obstaclePrefab is assigned
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle prefab is not assigned in the Inspector.");
            return; // Prevent further execution if prefab is not assigned
        }

        // Start spawning obstacles at a repeating interval
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Ensure obstaclePrefab is assigned before instantiating
        if (obstaclePrefab != null)
        {
            // Randomly choose an x position for the obstacle
            float randomX = Random.Range(-spawnWidth, spawnWidth);

            // Set the spawn position at the bottom of the screen
            Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

            // Instantiate the obstacle at the spawn position
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Make sure the obstacle prefab has the necessary component
            if (obstacle.GetComponent<Obstacle>() != null)
            {
                obstacle.GetComponent<Obstacle>().StartMoving(obstacleSpeed);
            }
            else
            {
                Debug.LogError("The obstacle prefab doesn't have an 'Obstacle' component.");
            }
        }
        else
        {
            Debug.LogError("Obstacle prefab is null in the SpawnObstacle method.");
        }
    }
}

