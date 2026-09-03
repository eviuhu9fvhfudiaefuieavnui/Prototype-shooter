using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip gunSound; // Sound that plays when player shoots
    public GameObject bulletPrefab; // The bullet object that gets spawned
    public Transform firePoint; // Where the bullet spawns from (end of gun)

    public void Fire()
    {
        // Play gun sound when shooting
        AudioManager.instance.PlaySound(gunSound);

        // Only shoot if bullet and firepoint are assigned
        if (bulletPrefab != null && firePoint != null)
        {
            // Get the mouse position in the game world
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Keep it 2D by setting z to 0

            // Work out direction from firepoint to mouse cursor
            Vector2 direction = (mousePos - firePoint.position).normalized;

            // Spawn the bullet at the firepoint position
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Launch the bullet in the direction of the mouse
            bullet.GetComponent<Bullet>().Launch(direction);
        }

        Debug.Log("Gun fired!");
    }
}