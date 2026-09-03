using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // How fast the bullet travels
    public int damage = 1; // How much damage bullet does to enemy

    public void Launch(Vector2 direction)
    {
        // Push bullet in the direction it was fired using physics
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        // Automatically delete bullet after 3 seconds if it hits nothing
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If bullet touches player, ignore it and do nothing
        if (collision.CompareTag("Player"))
            return;

        // If bullet touches wall, delete the bullet
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
            return;
        }

        // If bullet touches enemy, damage them and delete bullet
        if (collision.CompareTag("Enemy"))
        {
            // Call TakeDamage on the enemy
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);

            // Delete bullet after hitting enemy
            Destroy(gameObject);
        }
    }
}