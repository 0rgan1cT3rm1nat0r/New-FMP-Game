using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageInterval = 0.5f;

    private Dictionary<GameObject, float> nextDamageTime = new Dictionary<GameObject, float>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Damage once on enter
                nextDamageTime[other.gameObject] = Time.time + damageInterval;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                if (!nextDamageTime.ContainsKey(other.gameObject))
                    nextDamageTime[other.gameObject] = Time.time;

                if (Time.time >= nextDamageTime[other.gameObject])
                {
                    playerHealth.TakeDamage(damageAmount);
                    nextDamageTime[other.gameObject] = Time.time + damageInterval;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nextDamageTime.ContainsKey(other.gameObject))
        {
            nextDamageTime.Remove(other.gameObject);
        }
    }

    private void OnDisable()
    {
        nextDamageTime.Clear();
    }
}



/*
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
*/