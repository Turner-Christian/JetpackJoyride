using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathScreen; // Reference to the death screen GameObject

    private void Start() {
        deathScreen.SetActive(false); // Hide the death screen at the start
    }
    // Update is called once per frame
    void Update()
    {
        if (GmeManager.PlayerIsDead) // Check if the player is dead
        {
            ShowDeathScreen(); // Show the death screen
        }
        
    }

    public void ShowDeathScreen()
    {
        // GmeManager.GmeScoreText.text = "SCORE: " + GmeManager.score; // Update the score text on the death screen
        deathScreen.SetActive(true); // Show the death screen
    }
}
