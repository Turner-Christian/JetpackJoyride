using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.SceneManagement;

public class GmeManager : MonoBehaviour
{
    static public bool PlayerIsDead = false; // Flag to check if the player is dead
    static public int score; // Variable to store the score
    public GameObject player; // Reference to the player object
    public GameObject deathScreen; // Reference to the death screen GameObject
    public TextMeshProUGUI GmeScoreText; // Reference to the score text object

    private bool hasDied = false;

    private void Start() {
        PlayerIsDead = false; // Initialize the player dead flag to false
        deathScreen.SetActive(false); // Hide the death screen at the start
    }

    private void Update() {
        if (player == null && !hasDied)
        { // Check if the player object is destroyed and has not already died{
            hasDied = true; // Set the hasDied flag to true to prevent multiple calls
            HighScore(); // Update the score text with the current score
            PlayerIsDead = true; // Set the player dead flag to true if the player object is destroyed
            deathScreen.SetActive(true); // Show the death screen
        } else {
            PlayerIsDead = false; // Set the player dead flag to false if the player object exists
        }
    }

    public void RestartClick()
    {
        SceneManager.LoadScene("GameScene"); // Load the game scene when the start button is clicked
    }

    public void HighScore()
    {
        if(!PlayerPrefs.HasKey("Highscore") || score > PlayerPrefs.GetInt("Highscore")) // Check if the current score is higher than the saved high score
        {
            GmeScoreText.text = "NEW HIGH SCORE: " + score.ToString("F0"); // Update the score text with the current score
            PlayerPrefs.SetInt("Highscore", score);
        }
        else {
            GmeScoreText.text = "SCORE: " + score.ToString("F0"); // Update the score text with the current score
        }
    }
}
