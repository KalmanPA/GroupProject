using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish : MonoBehaviour
{
    public float detectionRadius = 10f;  // Radius to search for enemies
    private NavMeshAgent navMeshAgent;   // Reference to the NavMeshAgent component
    private GameObject closestEnemy;     // Variable to store the closest enemy's GameObject

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindClosestEnemy();  // Find the initial closest enemy
        AudioManager.Instance.Play("FishStart");
        //navMeshAgent.speed = 8f;
    }

    void Update()
    {
        // Continuously update the closest enemy and chase it if it's moving
        if (closestEnemy != null)
        {
            navMeshAgent.SetDestination(closestEnemy.transform.position);
        }
        else
        {
            // If no closest enemy was found, find a new one
            FindClosestEnemy();
        }
    }

    private void OnDisable()
    {
        
    }

    void FindClosestEnemy()
    {
        // Find all colliders within the specified detection radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);

        float closestDistance = Mathf.Infinity; // Reset the closest distance for this check

        // Loop through all the colliders found
        foreach (Collider collider in hitColliders)
        {
            // Check if the collider has the tag "Enemy"
            if (collider.CompareTag("Enemy"))
            {
                // Calculate the distance from the current position to the enemy
                float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);

                // Check if this enemy is the closest one found so far
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = collider.gameObject;
                }
            }
        }

        // If a closest enemy was found, set the initial destination of the NavMeshAgent
        if (closestEnemy != null)
        {
            navMeshAgent.SetDestination(closestEnemy.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStateMachine>().ScareEnemy();

            AudioManager.Instance.Play("FishStop");

            gameObject.SetActive(false);
        }
    }
}
