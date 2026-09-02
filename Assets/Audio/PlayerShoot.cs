using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip gunSound;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public void Fire()
    {
        AudioManager.instance.PlaySound(gunSound);

        if (bulletPrefab != null && firePoint != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 direction = (mousePos - firePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Launch(direction);
        }

        Debug.Log("Gun fired!");
    }
}