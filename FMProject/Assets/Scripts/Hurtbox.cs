using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    // Reference to the player's health component
    public HealthManager playerHealth;

    // Damage value to apply on collision
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("ENTER");

            // Check if playerHealth is assigned and reduce health
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("STAY");

            // Optionally, deal continuous damage while staying in the trigger zone
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("EXIT");
        }
    }
}