using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Log what object has entered the trigger
        Debug.Log("Collision detected with: " + other.gameObject.name);

        // Check if the collided object is an enemy (tagged as "clone")
        if (other.CompareTag("Border hb"))
        {
            Debug.Log("Enemy out of bounds!");


            gameObject.SetActive(false); // Disable the enemy

            // Optional: Add any additional game over logic here
        }
    }
}