using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component for animations
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 2f; // Jump force applied to the player
    public float fallForce = 2f; // Fall force applied to the player

    private float horizontalInput; // Horizontal input value
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    bool isGrounded; // Check if the player is on the ground
    Vector2 rocketJumpForce; // Force applied for rocket jump

    private void Start() {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
        rocketJumpForce = new Vector2(0, jumpForce*2);

        if (animator == null) {
            Debug.LogError("Animator component not found on the player object.");
        }
        if (rb == null) {
            Debug.LogError("Rigidbody component not found on the player object.");
        }
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)

        if (Input.GetKey(KeyCode.Space)) { // Check if the space key is pressed for rocket jump
            RocketJump(); // Call the RocketJump method
        }

        // if (!Input.GetKey(KeyCode.Space) && !isGrounded) {
        //     rb.GravityScale = fallForce; // Apply fall force if not grounded and space key is not pressed
        // }
        // else {
        //     rb.GravityScale = 1; // Reset gravity scale to normal if grounded or space key is pressed
        // }


        if (horizontalInput != 0) {
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y); // Move the player horizontally
            animator.SetBool("IsRunning", true); // Set the animator parameter to indicate running
        }
        else {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop horizontal movement if no input
            animator.SetBool("IsRunning", false); // Set the animator parameter to indicate movement
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) { // Check if the player collides with an object tagged as "Ground"
            isGrounded = true; // Set isGrounded to true
        }
    }

    private void RocketJump() {
        rb.AddForce(rocketJumpForce); // Apply rocket jump force to the player
    }
}
