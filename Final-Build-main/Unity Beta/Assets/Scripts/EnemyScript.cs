using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public ParticleSystem particles;
    public int health;
    public int attack;
    public float speed = 3.0f;

    void Start()
    {
        // Get the ParticleSystem component attached to this GameObject
        particles = GetComponent<ParticleSystem>();

        // Get the Rigidbody component attached to this GameObject
        enemyRb = GetComponent<Rigidbody>();

        // Find the player GameObject by name
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Calculate the normalized direction vector from the enemy to the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Apply force to the enemy in the direction of the player
        enemyRb.AddForce(lookDirection * speed);

    }
}
