using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void onStartClick()
    {
        SceneManager.LoadScene("GameScene"); // Load the game scene when the start button is clicked
    }

    public void onExitClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #endif
            Application.Quit(); // Quit the application
    }
}
