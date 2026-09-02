using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Background music
    public AudioClip victorySound; // Sound when all enemies killed
    public AudioClip loseSound; // Sound when player dies

    private void Start()
    {
        // Play background music when game starts
        if (backgroundMusic != null)
        {
            AudioManager.instance.PlayMusic(backgroundMusic);
        }
    }

    // Call when all enemies are dead
    public void Victory()
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySound(victorySound);
        Debug.Log("Victory!");
    }

    // Call when player dies
    public void Lose()
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySound(loseSound);
        Debug.Log("You lost!");
    }
}