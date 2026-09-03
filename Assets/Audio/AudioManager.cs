using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // One AudioManager exists for the whole game (Singleton)
    public static AudioManager instance;

    // Two separate audio players - one for sounds, one for music
    public AudioSource soundEffectsPlayer;
    public AudioSource musicPlayer;

    // Volume levels (0 = silent, 1 = full volume)
    public float sfxVolume = 0.8f;
    public float musicVolume = 0.5f;

    private void Awake()
    {
        // If no AudioManager exists, make this one the main one
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // If one already exists, delete this duplicate
            Destroy(gameObject);
            return;
        }

        // If no sound effects player exists, create one automatically
        if (soundEffectsPlayer == null)
        {
            soundEffectsPlayer = gameObject.AddComponent<AudioSource>();
            soundEffectsPlayer.volume = sfxVolume;
        }

        // If no music player exists, create one automatically
        if (musicPlayer == null)
        {
            musicPlayer = gameObject.AddComponent<AudioSource>();
            musicPlayer.volume = musicVolume;
            musicPlayer.loop = true; // Music repeats when it ends
        }
    }

    // Play a short sound effect once (gun shot, death, etc.)
    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            soundEffectsPlayer.PlayOneShot(clip);
        }
    }

    // Play background music on loop
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicPlayer.clip = clip;
            musicPlayer.Play();
        }
    }

    // Stop the background music
    public void StopMusic()
    {
        musicPlayer.Stop();
    }
}