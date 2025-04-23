using UnityEngine;
using TMPro; // Import TextMeshPro namespace

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
        timeAlive += Time.deltaTime; // Increment timeAlive by the time since the last frame
        scoreText.text = "Score: " + Mathf.FloorToInt(timeAlive); // Update the score text with the time alive
    }
}
