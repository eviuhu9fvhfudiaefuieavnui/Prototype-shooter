using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip footstepSound; // Sound that plays when player walks
    public float footstepInterval = 0.4f; // How often footstep plays (every 0.4 seconds)
    private float footstepTimer = 0f; // Counts down to next footstep sound
    private Rigidbody2D rb; // Used to check if player is moving

    private void Start()
    {
        // Get the Rigidbody2D to check player movement speed
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if player is actually moving (magnitude is the speed)
        // If speed is more than 0.1, player is moving
        if (rb.velocity.magnitude > 0.1f)
        {
            // Count down the timer each frame
            footstepTimer -= Time.deltaTime;

            // When timer hits 0, play footstep and reset timer
            if (footstepTimer <= 0)
            {
                AudioManager.instance.PlaySound(footstepSound);
                footstepTimer = footstepInterval; // Reset timer back to 0.4 seconds
            }
        }
    }
}