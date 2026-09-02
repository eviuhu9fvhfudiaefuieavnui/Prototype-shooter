using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip footstepSound;
    public float footstepInterval = 0.4f;
    private float footstepTimer = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if player is moving
        if (rb.velocity.magnitude > 0.1f)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0)
            {
                AudioManager.instance.PlaySound(footstepSound);
                footstepTimer = footstepInterval;
            }
        }
    }
}