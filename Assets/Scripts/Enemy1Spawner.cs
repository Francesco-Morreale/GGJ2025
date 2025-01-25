using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject Enemy1; // Reference to the enemy prefab
    public float SpawnInterval = 2.0f; // Time interval between spawns
    public GameObject PlayerModelTest; // Reference to the player model
    public float minSpawnDistance = 8.0f; // Minimum distance from the player for spawning
    public float maxSpawnDistance = 15.0f; // Maximum distance from the player for spawning

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, SpawnInterval);
    }

    void SpawnObject()
    {
        Vector3 playerPosition = PlayerModelTest.transform.position;

        // Generate a random angle and distance
        float randomAngle = Random.Range(0f, 720f); // Random angle in degrees
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance); // Random distance from player

        // Calculate spawn position using polar coordinates
        Vector3 spawnPosition = new Vector3(
            playerPosition.x + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomDistance,
            playerPosition.y + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomDistance, // Random Y offset above the player
            0
        );

        // Check if the spawn position is valid before instantiation
        if (IsValidSpawnPosition(spawnPosition))
        {
            Instantiate(Enemy1, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Invalid spawn position detected.");
        }
    }

    bool IsValidSpawnPosition(Vector3 position)
    {
        // Check if there are any colliders within a sphere around the spawn position
        return !Physics.CheckSphere(position, minSpawnDistance);
    }

    // Update is called once per frame
    void Update()
    {
    }
}