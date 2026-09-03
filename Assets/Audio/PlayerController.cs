using UnityEngine; // Gives access to Unity features

public class PlayerController : MonoBehaviour // MonoBehaviour lets this attach to a GameObject
{
    public float moveSpeed = 5f; // How fast the player moves
    public int health = 3; // Player starts with 3 health points
    public AudioClip deathSound; // Sound when player dies
    public AudioClip hurtSound; // Sound when player gets hit but survives
    public AudioClip wallHitSound; // Sound when player hits a wall
    private Rigidbody2D rb; // Controls player physics movement

    private void Start() // Runs once when the game starts
    {
        // Get the Rigidbody2D so we can move the player using physics
        rb = GetComponent<Rigidbody2D>(); // Find and store the Rigidbody2D component
    }

    private void Update() // Runs every frame
    {
        // Get keyboard input from WASD or arrow keys (-1 to 1)
        float moveX = Input.GetAxis("Horizontal"); // Left/right input
        float moveY = Input.GetAxis("Vertical"); // Up/down input

        // Move the player based on input and speed
        rb.velocity = new Vector2(moveX, moveY) * moveSpeed; // Set player velocity

        // Left click mouse to shoot
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button was clicked
        {
            GetComponent<PlayerShoot>().Fire(); // Find PlayerShoot script and call Fire method
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Runs when player touches a trigger collider
    {
        // Check if what touched player is an enemy
        if (collision.CompareTag("Enemy")) // Check if the collider has Enemy tag
        {
            // Take away 1 health point
            health--; // Reduce health by 1
            Debug.Log("Player hit! Health: " + health); // Print health to console

            // If health is 0 or less, player dies
            if (health <= 0) // Check if player is dead
            {
                // Play death sound
                AudioManager.instance.PlaySound(deathSound); // Play death sound through AudioManager

                Debug.Log("Player died!"); // Print to console

                // Tell GameManager to trigger lose state
                FindObjectOfType<GameManager>().Lose(); // Find GameManager and call Lose method

                // Remove player from scene
                Destroy(gameObject); // Delete the player GameObject
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Runs when player physically collides with something
    {
        // If player hits wall, play wall hit sound
        if (collision.gameObject.CompareTag("Wall")) // Check if collided object has Wall tag
        {
            AudioManager.instance.PlaySound(wallHitSound); // Play wall hit sound through AudioManager
        }
    }
}