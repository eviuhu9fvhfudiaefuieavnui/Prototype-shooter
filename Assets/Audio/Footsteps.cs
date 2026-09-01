using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip footstepSound;
    public float footstepInterval = 0.4f; // Play every 0.4 seconds
    private float footstepTimer = 0f;
    private Rigidbody2D rb;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if player is moving
        isMoving = rb.velocity.magnitude > 0.1f;

        if (isMoving)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0)
            {
                PlayFootstep();
                footstepTimer = footstepInterval;
            }
        }
    }

    private void PlayFootstep()
    {
        if (footstepSound != null)
        {
            AudioManager.instance.PlaySound(footstepSound);
        }
    }
}