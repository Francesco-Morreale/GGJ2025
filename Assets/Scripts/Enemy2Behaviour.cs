using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behaviour : MonoBehaviour
{
    public Transform Player; // Reference to the player
    public float minSpeed = 5.0f; // Minimum speed of the enemy
    public float maxSpeed = 15.0f; // Maximum speed of the enemy
    public float acceleration = 5.0f; // How quickly the enemy accelerates towards the player
    public float turnSpeed = 2.0f; // Maximum turning speed in radians per second
    public float missFactor = 1.0f; // How much randomness is added to movement
    public float followDistance = 10.0f; // Distance within which the enemy will actively follow the player

    private float currentSpeed; // Current speed of the enemy
    private Vector3 targetDirection; // Current target direction

    void Start()
    {
        currentSpeed = minSpeed; // Initialize speed
        targetDirection = transform.up; // Initialize target direction
    }

    void Update()
    {
        if (Player != null)
        {
            // Calculate direction to player but keep Z zeroed for 2D movement
            Vector3 directionToPlayer = Player.position - transform.position;
            directionToPlayer.z = 0;

            // Calculate distance to player
            float distanceToPlayer = directionToPlayer.magnitude;

            // Adjust speed based on distance (closer means faster)
            if (distanceToPlayer < followDistance)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * acceleration);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, minSpeed, Time.deltaTime * acceleration);
            }

            // Introduce randomness to allow for missing (curving away from direct path)
            float randomOffsetX = Random.Range(-missFactor, missFactor);
            float randomOffsetY = Random.Range(-missFactor, missFactor);

            // Calculate target position with randomness but keep Y constant
            Vector3 targetPosition = new Vector3(Player.position.x + randomOffsetX, Player.position.y + randomOffsetY, 0);

            // Calculate target direction towards modified target position
            Vector3 desiredDirection = (targetPosition - transform.position).normalized;

            // Smoothly turn towards the desired direction using limited turn speed
            targetDirection = Vector3.RotateTowards(targetDirection, desiredDirection, turnSpeed * Time.deltaTime, 0.0f);

            // Move in the new direction while keeping Z constant
            transform.position += targetDirection * currentSpeed * Time.deltaTime;

            // Optional: Debugging log to visualize movement
            Debug.Log($"Enemy Position: {transform.position}, Target Direction: {targetDirection}, Speed: {currentSpeed}");
        }
    }
}



