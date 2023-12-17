using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Reference to the player target (assumes player has "Player" tag)
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player GameObject using the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player is found
        if (player != null)
        {
            // Assign the player's transform as the target for the camera
            target = player.transform;
        }
        else
        {
            // Log a warning if the player is not found
            Debug.LogWarning("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This method is called every frame
        // You can use it for input handling, user interface updates, or other frame-dependent actions
    }

    // FixedUpdate is called at a fixed time interval, independent of frame rate
    private void FixedUpdate()
    {
        // This method is commonly used for physics-related calculations
        // Camera smoothly looks at the target position
        // Note: If you're following a moving object, using LateUpdate might be more appropriate
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
