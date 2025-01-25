using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{
    public Transform Player; // Reference to the player
    public float minSpeed = 9.0f; // Minimum speed of the enemy
    public float maxSpeed = 15.0f; // Maximum speed of the enemy
    public float minSlope = 1.0f; // Minimum slope for X movement
    public float maxSlope = 5.0f; // Maximum slope for X movement

    private Vector3 moveDirection; // Direction in which the enemy is moving
    private float speed; // Current speed of the enemy

    void Start()
    {
        // Randomize speed when the enemy is spawned
        speed = Random.Range(minSpeed, maxSpeed);

        if (Player != null)
        {
            // Calculate direction to player with a vertical offset
            Vector3 directionToPlayer = Player.position - transform.position;

            // Calculate random slope ensuring it's not too low
            float randomSlope = Random.Range(minSlope, maxSlope);
            float deltaX = directionToPlayer.y * randomSlope;

            // Create target position in front of the player with adjusted X and Y
            Vector3 targetPos = new Vector3(transform.position.x + deltaX, Player.position.y, transform.position.z);

            // Calculate move direction towards target position
            moveDirection = (targetPos - transform.position).normalized;
        }
    }

    void Update()
    {
        // Move the enemy in the calculated direction
        transform.position += moveDirection * speed * Time.deltaTime;

        // Optional: Debugging log to visualize movement
        Debug.Log($"Enemy Position: {transform.position}, Move Direction: {moveDirection}, Speed: {speed}");
    }
}