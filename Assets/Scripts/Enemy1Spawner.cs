using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject Enemy1; // Reference to the enemy prefab
    public float SpawnInterval = 2.0f; // Time interval between spawns
    public GameObject PlayerModelTest; // Reference to the player model
    public float yOffset = 0.5f; // Fixed offset above the player (can be adjusted)

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, SpawnInterval);
    }

    void SpawnObject()
    {
        // Get the player's current position
        Vector3 playerPosition = PlayerModelTest.transform.position;

        // Calculate spawn position near the player with a fixed Y coordinate
        Vector3 spawnPosition = new Vector3(
            playerPosition.x + Random.Range(-5f, 7f), // Random X offset near the player
            playerPosition.y + yOffset+Random.Range(-5f, 7f),              // Fixed Y offset above the player
            playerPosition.z                           // Same Z coordinate as the player
        );

        // Instantiate the enemy at the calculated spawn position
        Instantiate(Enemy1, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}