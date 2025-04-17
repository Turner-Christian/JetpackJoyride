using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    public Animator animator; // Reference to the Animator component for animations
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 5f; // Jump force of the player
    private float horizontalInput; // Horizontal input value

    private void Start() {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player

        if (animator == null) {
            Debug.LogError("Animator component not found on the player object.");
        }
        if (rb == null) {
            Debug.LogError("Rigidbody component not found on the player object.");
        }
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)

        if (Input.GetButtonDown("Jump")) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force to the player
            // animator.SetBool("IsJumping", true); // Set the animator parameter to indicate jumping
        }

        if (horizontalInput != 0) {
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y); // Move the player horizontally
            animator.SetBool("IsRunning", true); // Set the animator parameter to indicate running
        }
        else {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop horizontal movement if no input
            animator.SetBool("IsRunning", false); // Set the animator parameter to indicate movement
        }
    }
}
