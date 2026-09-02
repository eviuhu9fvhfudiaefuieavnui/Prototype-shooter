using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // How fast player moves
    public int health = 3; // Player health
    public AudioClip deathSound; // Sound when player dies
    public AudioClip hurtSound; // Sound when player gets hit
    private Rigidbody2D rb; // Player physics

    private void Start()
    {
        // Get physics component
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get WASD input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Move player
        rb.velocity = new Vector2(moveX, moveY) * moveSpeed;

        // Left click to shoot
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<PlayerShoot>().Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy touches player
        if (collision.CompareTag("Enemy"))
        {
            health--;
            Debug.Log("Player hit! Health: " + health);

            if (health <= 0)
            {
                // Play death sound
                AudioManager.instance.PlaySound(deathSound);
                Debug.Log("Player died!");

                // Play lose sound
                FindObjectOfType<GameManager>().Lose();

                // Remove player
                Destroy(gameObject);
            }
            else
            {
                // Play hurt sound when hit but not dead
                AudioManager.instance.PlaySound(hurtSound);
            }
        }
    }
}