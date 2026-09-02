using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound; // Sound when enemy dies
    public AudioClip screamSound; // Sound when enemy chases player
    public int health = 1; // How many hits before enemy dies
    public float speed = 2f; // How fast enemy moves
    public float screamInterval = 3f; // Scream every 3 seconds
    private float screamTimer = 0f; // Timer to track scream interval
    private Rigidbody2D rb; // Enemy physics
    private Transform player; // Reference to player position

    private void Start()
    {
        // Get the physics component
        rb = GetComponent<Rigidbody2D>();

        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Play scream sound when enemy spawns
        AudioManager.instance.PlaySound(screamSound);
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate direction from enemy to player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move enemy towards player
            rb.velocity = direction * speed;

            // Scream every few seconds while chasing
            screamTimer -= Time.deltaTime;
            if (screamTimer <= 0)
            {
                AudioManager.instance.PlaySound(screamSound);
                screamTimer = screamInterval;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health when hit
        health -= damage;

        // Check if enemy is dead
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play death sound
        AudioManager.instance.PlaySound(deathSound);
        Debug.Log("Enemy died!");

        // Check if all enemies are dead
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
        {
            FindObjectOfType<GameManager>().Victory();
        }

        // Remove enemy from scene
        Destroy(gameObject);
    }
}