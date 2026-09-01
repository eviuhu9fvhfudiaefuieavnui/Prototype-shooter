using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound;
    public int health = 1;
    public float speed = 2f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

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
        AudioManager.instance.PlaySound(deathSound);
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}