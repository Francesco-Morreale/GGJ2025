using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject Enemy; // Reference to the enemy prefab
    public float SpawnInterval = 2.0f; // Time interval between spawns
    public GameObject Player; // Reference to the player model
    public float Offset = 3.0f; // Height above the player where enemies will spawn
    public float SpawnRangeX = 10.0f; // Range for random x-coordinates
    public float SpawnHeightMin;
    public float SpawnHeightMax;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, SpawnInterval);
    }

    void SpawnObject()
    {
        Vector3 playerPosition = Player.transform.position;

        // Generate a random x-coordinate within the specified range
        float randomX = Random.Range(-SpawnRangeX, SpawnRangeX);

        // Set the spawn position directly above the player with an offset
        Vector3 spawnPosition = new Vector3(randomX, playerPosition.y + 10 * Offset, 0);

        // Instantiate the enemy at the calculated spawn position
        if (playerPosition.y > SpawnHeightMin && playerPosition.y < SpawnHeightMax)
        {
            Instantiate(Enemy, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        // Additional update logic can go here if needed
    }
}
