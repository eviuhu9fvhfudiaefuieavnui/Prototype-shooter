using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip backgroundMusic;

    private void Start()
    {
        // Play background music when game starts
        if (backgroundMusic != null)
        {
            AudioManager.instance.PlayMusic(backgroundMusic);
        }
    }
}