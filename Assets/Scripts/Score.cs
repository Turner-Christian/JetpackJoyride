using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using System; // Import System namespace for Math.Round

public class Score : MonoBehaviour
{
    private float timeAlive; // Time the object has been alive
    public TextMeshProUGUI scoreText; // Reference to the score text object
    public GameObject player; // Reference to the player object
    // Update is called once per frame
    void Awake()
    {
        timeAlive = 0; // Initialize timeAlive to 0
    }

    void Update()
    {   
        if(GmeManager.PlayerIsDead) // Check if the player is dead
        {
            return; // Exit the Update method if the player is dead
        }
        else
        {
            timeAlive += Time.deltaTime; // Increment timeAlive by the time since the last frame
            scoreText.text = "SCORE " + (Math.Round(timeAlive, 2) * 10).ToString("F0"); // Update the score text with the time alive
            GmeManager.score = (Math.Round(timeAlive, 2) * 10).ToString("F0");  // Update the score in the GameManager
        }
    }
}
