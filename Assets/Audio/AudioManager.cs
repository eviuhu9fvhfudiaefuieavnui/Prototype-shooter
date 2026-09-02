using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource soundEffectsPlayer;
    public AudioSource musicPlayer;
    public float sfxVolume = 0.8f;
    public float musicVolume = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (soundEffectsPlayer == null)
        {
            soundEffectsPlayer = gameObject.AddComponent<AudioSource>();
            soundEffectsPlayer.volume = sfxVolume;
        }

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

    public void StopMusic()
    {
        musicPlayer.Stop();
    }
}