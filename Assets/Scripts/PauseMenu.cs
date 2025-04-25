using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager namespace for scene management

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI; // Reference to the pause menu GameObject
    public bool isPaused; // Flag to check if the game is paused

    private void Start() {
        PauseMenuUI.SetActive(false); // Hide the pause menu at the start
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) { // Check if the Escape key is pressed
            if(isPaused) {
                ResumeGame(); // If the game is paused, resume it
            } else {
                PauseGame(); // If the game is not paused, pause it
            }
        }
    }

    public void PauseGame() {
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        PauseMenuUI.SetActive(true); // Show the pause menu
        isPaused = true; // Set the paused flag to true
    }

    public void ResumeGame() {
        Time.timeScale = 1f; // Resume the game by setting time scale to 1
        PauseMenuUI.SetActive(false); // Hide the pause menu
        isPaused = false; // Set the paused flag to false
    }

    public void GoToMenu() {
        Time.timeScale = 1f; // Resume the game before loading the menu
        SceneManager.LoadScene("StartScene"); // Load the start menu scene
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #endif
            Application.Quit(); // Quit the application
    }
}
