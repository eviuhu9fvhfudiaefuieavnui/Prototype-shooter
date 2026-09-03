using UnityEngine; // Gives access to Unity features

public class Bullet : MonoBehaviour // MonoBehaviour lets this attach to a GameObject
{
    public float speed = 10f; // How fast the bullet travels
    public int damage = 1; // How much damage bullet does to enemy

    public void Launch(Vector2 direction) // Called when bullet is fired, takes a direction as input
    {
        // Push bullet in the direction it was fired using physics
        GetComponent<Rigidbody2D>().velocity = direction * speed; // Set bullet speed in the given direction

        // Automatically delete bullet after 3 seconds if it hits nothing
        Destroy(gameObject, 3f); // Delete this bullet after 3 seconds
    }

    private void OnTriggerEnter2D(Collider2D collision) // Runs when bullet touches another collider
    {
        // If bullet touches player, ignore it and do nothing
        if (collision.CompareTag("Player")) // Check if the thing touched is the player
            return; // Stop here, do nothing

        // If bullet touches wall, delete the bullet
        if (collision.CompareTag("Wall")) // Check if the thing touched is a wall
        {
            Destroy(gameObject); // Delete the bullet
            return; // Stop running any more code
        }

        // If bullet touches enemy, damage them and delete bullet
        if (collision.CompareTag("Enemy")) // Check if the thing touched is an enemy
        {
            // Call TakeDamage on the enemy
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage); // Deal damage to the enemy

            // Delete bullet after hitting enemy
            Destroy(gameObject); // Delete the bullet
        }
    }
}