using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Reference to the enemy prefab to be spawned
    public GameObject enemyPrefab;

    // Number of enemies to spawn
    public int numberOfEnemies = 5;

    // Radius around existing enemies for new enemies to spawn
    public float spawnRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Initial spawn of enemies
        SpawnEnemies();
    }

    // SpawnEnemies method is responsible for spawning new enemies around existing ones
    void SpawnEnemies()
    {
        // Find all game objects with the "Enemy" tag in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Loop through each existing enemy
        foreach (GameObject enemy in enemies)
        {
            // Spawn the specified number of enemies around each existing enemy
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // Calculate a random spawn position around the current enemy
                Vector3 spawnPosition = RandomSpawnPositionAround(enemy.transform.position, spawnRadius);
                
                // Generate a random spawn rotation
                Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

                // Instantiate a new enemy at the calculated position and rotation
                Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            }
        }
    }

    // RandomSpawnPositionAround method calculates a random spawn position on a circle around a given center point
    Vector3 RandomSpawnPositionAround(Vector3 center, float radius)
    {
        // Generate a random angle within the full circle
        float angle = Random.Range(0f, 360f);
        
        // Calculate the x, y, and z coordinates based on the angle and radius
        float spawnX = center.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float spawnZ = center.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        float spawnY = center.y;

        // Return the calculated spawn position as a Vector3
        return new Vector3(spawnX, spawnY, spawnZ);
    }
}
