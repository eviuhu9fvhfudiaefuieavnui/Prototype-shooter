using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // How fast the player moves
    public int health = 3; // Player starts with 3 health points
    public AudioClip deathSound; // Sound when player dies
    public AudioClip hurtSound; // Sound when player gets hit but survives
    private Rigidbody2D rb; // Controls player physics movement

    private void Start()
    {
        // Get the Rigidbody2D so we can move the player using physics
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get keyboard input from WASD or arrow keys (-1 to 1)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Move the player based on input and speed
        rb.velocity = new Vector2(moveX, moveY) * moveSpeed;

        // Left click mouse to shoot
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<PlayerShoot>().Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if what touched player is an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Take away 1 health point
            health--;
            Debug.Log("Player hit! Health: " + health);

            // If health is 0 or less, player dies
            if (health <= 0)
            {
                // Play death sound
                AudioManager.instance.PlaySound(deathSound);
                Debug.Log("Player died!");

                // Tell GameManager to trigger lose state
                FindObjectOfType<GameManager>().Lose();

                // Remove player from scene
                Destroy(gameObject);
            }
            else
            {
                // Player got hit but still alive, play hurt sound
                AudioManager.instance.PlaySound(hurtSound);
            }
        }
    }
}