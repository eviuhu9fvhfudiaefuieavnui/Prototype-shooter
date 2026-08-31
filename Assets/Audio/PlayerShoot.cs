using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip gunSound;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public void Fire()
    {
        // Play gun sound
        AudioManager.instance.PlaySound(gunSound);

        // Spawn bullet
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }

        Debug.Log("Gun fired!");
    }
}