using UnityEngine;

public class GmeManager : MonoBehaviour
{
    static public bool PlayerIsDead = false; // Flag to check if the player is dead
    static public string score; // Variable to store the score

    private void Update() {
        // Check if the player is dead
        if (PlayerIsDead) {
            // Optionally, you can show a game over screen or restart the game here
            // For example, you can load a game over scene or display a UI panel
            // SceneManager.LoadScene("GameOverScene");
            // or show a UI panel
            // gameOverPanel.SetActive(true);
            // Restart the game when the player presses R

        }
    }
}
