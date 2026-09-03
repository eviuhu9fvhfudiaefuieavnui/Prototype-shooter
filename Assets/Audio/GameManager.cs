using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Music that plays throughout the game
    public AudioClip victorySound; // Sound that plays when all enemies are killed
    public AudioClip loseSound; // Sound that plays when player dies

    private void Start()
    {
        // When the game starts, play the background music
        if (backgroundMusic != null)
        {
            AudioManager.instance.PlayMusic(backgroundMusic);
        }
    }

    // This runs when all enemies are dead
    public void Victory()
    {
        // Stop the background music so it doesnt clash with victory sound
        AudioManager.instance.StopMusic();

        // Play the victory sound
        AudioManager.instance.PlaySound(victorySound);

        // Freeze the game so nothing moves after winning
        Time.timeScale = 0f;

        Debug.Log("Victory!");
    }

    // This runs when the player dies
    public void Lose()
    {
        // Stop the background music so it doesnt clash with lose sound
        AudioManager.instance.StopMusic();

        // Play the lose sound
        AudioManager.instance.PlaySound(loseSound);

        // Freeze the game so nothing moves after losing
        Time.timeScale = 0f;

        Debug.Log("You lost!");
    }
}