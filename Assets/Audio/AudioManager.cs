using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // These hold the sound players
    public AudioSource soundEffectsPlayer;
    public AudioSource musicPlayer;

    // Control the loudness (0 = silent, 1 = full volume)
    public float sfxVolume = 0.8f;
    public float musicVolume = 0.5f;

    private void Awake()
    {
        // Make sure we only have ONE AudioManager in the game
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Create the sound effect player if it doesn't exist
        if (soundEffectsPlayer == null)
        {
            soundEffectsPlayer = gameObject.AddComponent<AudioSource>();
            soundEffectsPlayer.volume = sfxVolume;
        }

        // Create the music player if it doesn't exist
        if (musicPlayer == null)
        {
            musicPlayer = gameObject.AddComponent<AudioSource>();
            musicPlayer.volume = musicVolume;
            musicPlayer.loop = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            soundEffectsPlayer.PlayOneShot(clip);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicPlayer.clip = clip;
            musicPlayer.Play();
        }
    }

    //stops the music
    public void StopMusic()
    { 
        musicPlayer.Stop();
    }

} 