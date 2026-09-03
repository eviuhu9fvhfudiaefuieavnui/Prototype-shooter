using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound; // Sound when enemy dies
    public AudioClip screamSound; // Sound when enemy chases player
    public int health = 1; // How many hits before enemy dies
    public float speed = 2f; // How fast enemy moves
    public float screamInterval = 3f; // How often enemy screams (in seconds)
    private float screamTimer = 0f; // Counts down to next scream
    private Rigidbody2D rb; // Controls enemy physics movement
    private Transform player; // Stores where the player is

    private void Start()
    {
        // Get the Rigidbody2D so we can move the enemy using physics
        rb = GetComponent<Rigidbody2D>();

        // Find the player in the scene using their "Player" tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Play scream sound as soon as enemy appears in game
        AudioManager.instance.PlaySound(screamSound);
    }

    private void Update()
    {
        // Only move if player exists in the scene
        if (player != null)
        {
            // Work out which direction the player is from the enemy
            Vector2 direction = (player.position - transform.position).normalized;

            // Push enemy towards player using physics
            rb.velocity = direction * speed;

            // Count down the scream timer each frame
            screamTimer -= Time.deltaTime;

            // When timer hits 0, scream and reset timer
            if (screamTimer <= 0)
            {
                AudioManager.instance.PlaySound(screamSound);
                screamTimer = screamInterval; // Reset timer back to 3 seconds
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Subtract damage from health
        health -= damage;

        // If health is 0 or less, enemy dies
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play death sound when enemy is killed
        AudioManager.instance.PlaySound(deathSound);
        Debug.Log("Enemy died!");

        // Check if this was the last enemy in the scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            // Tell GameManager to trigger victory
            FindObjectOfType<GameManager>().Victory();
        }

        // Delete the enemy from the scene
        Destroy(gameObject);
    }
}