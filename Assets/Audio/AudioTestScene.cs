using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestScene : MonoBehaviour
{
    // Drag your audio files into these slots in the Inspector
    public AudioClip goldSound; // Sound for collecting gold
    public AudioClip doorSound; // Sound for unlocking door
    public AudioClip backgroundMusic; // Background music for the game

    // Update runs every frame and checks for keyboard input
    private void Update()
    {
        // Press G key to test gold collection sound
        if (Input.GetKeyDown(KeyCode.G))
        {
            AudioManager.instance.PlaySound(goldSound);
            Debug.Log("Gold sound played!");
        }

        // Press D key to test door unlock sound
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.instance.PlaySound(doorSound);
            Debug.Log("Door sound played!");
        }

        // Press M key to test background music
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.instance.PlayMusic(backgroundMusic);
            Debug.Log("Music started!");
        }

        // Press S key to stop the music
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.StopMusic();
            Debug.Log("Music stopped!");
        }
    }
}