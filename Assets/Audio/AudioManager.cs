using UnityEngine; // Gives access to Unity features

public class AudioManager : MonoBehaviour // MonoBehaviour lets this attach to a GameObject
{
    // One AudioManager exists for the whole game (Singleton)
    public static AudioManager instance; // Stores the one AudioManager for the whole game

    // Two separate audio players - one for sounds, one for music
    public AudioSource soundEffectsPlayer; // Plays short sound effects
    public AudioSource musicPlayer; // Plays background music

    // Volume levels (0 = silent, 1 = full volume)
    public float sfxVolume = 0.8f; // Sound effects volume set to 80%
    public float musicVolume = 0.5f; // Music volume set to 50%

    private void Awake() // Runs once when the game starts
    {
        // If no AudioManager exists, make this one the main one
        if (instance == null) // Check if an AudioManager already exists
        {
            instance = this; // Make this the main AudioManager
        }
        else
        {
            // If one already exists, delete this duplicate
            Destroy(gameObject); // Delete this duplicate AudioManager
            return; // Stop running any more code
        }

        // If no sound effects player exists, create one automatically
        if (soundEffectsPlayer == null) // Check if sound player exists
        {
            soundEffectsPlayer = gameObject.AddComponent<AudioSource>(); // Create sound player
            soundEffectsPlayer.volume = sfxVolume; // Set its volume
        }

        // If no music player exists, create one automatically
        if (musicPlayer == null) // Check if music player exists
        {
            musicPlayer = gameObject.AddComponent<AudioSource>(); // Create music player
            musicPlayer.volume = musicVolume; // Set its volume
            musicPlayer.loop = true; // Music repeats when it ends
        }
    }

    // Play a short sound effect once (gun shot, death, etc.)
    public void PlaySound(AudioClip clip) // Takes an audio clip as input
    {
        if (clip != null) // Make sure the clip actually exists
        {
            soundEffectsPlayer.PlayOneShot(clip); // Play the sound once without interrupting others
        }
    }

    // Play background music on loop
    public void PlayMusic(AudioClip clip) // Takes an audio clip as input
    {
        if (clip != null) // Make sure the clip actually exists
        {
            musicPlayer.clip = clip; // Assign the music clip to the player
            musicPlayer.Play(); // Start playing the music
        }
    }

    // Stop the background music
    public void StopMusic()
    {
        musicPlayer.Stop(); // Stop the music player immediately
    }
}