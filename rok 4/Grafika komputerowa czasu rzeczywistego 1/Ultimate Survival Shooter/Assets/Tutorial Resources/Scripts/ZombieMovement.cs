﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    IHealth playerHealth;      // Reference to the player's health.
    IHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<ZombieHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.CurrentHealth > 0 && playerHealth.CurrentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}
