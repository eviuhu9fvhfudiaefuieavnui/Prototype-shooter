using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestScene : MonoBehaviour
{
    // Drag your audio files into these in the Inspector
    public AudioClip goldSound;
    public AudioClip doorSound;
    public AudioClip backgroundMusic;

    private void Update()
    {
        // Press G key to play gold collection sound
        if (Input.GetKeyDown(KeyCode.G))
        {
            AudioManager.instance.PlaySound(goldSound);
            Debug.Log("Gold sound played!");
        }

        // Press D key to play door unlock sound
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.instance.PlaySound(doorSound);
            Debug.Log("Door sound played!");
        }

        // Press M key to play background music
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