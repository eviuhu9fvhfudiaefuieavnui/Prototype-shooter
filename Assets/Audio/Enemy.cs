using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound;
    public int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy hit! Health: " + health);

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
        Destroy(gameObject);
    }
}
