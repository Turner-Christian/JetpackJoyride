using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem particles; // Reference to the ParticleSystem for visual effects
    public Animator animator; // Reference to the Animator component for animations
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 1f; // Jump force applied to the player
    public float smallJumpForce = 2f; // Small jump force applied to the player
    public float fallForce = 3.5f; // Fall force applied to the player

    private float horizontalInput; // Horizontal input value
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    Vector2 rocketJumpForce; // Force applied for rocket jump

    private void Start() {
        particles = GetComponentInChildren<ParticleSystem>(); // Get the ParticleSystem component attached to the player
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
        rocketJumpForce = new Vector2(0, jumpForce*2);
        particles.gameObject.SetActive(false); // Deactivate the particle effect at the start

        if (animator == null) {
            Debug.LogError("Animator component not found on the player object.");
        }
        if (rb == null) {
            Debug.LogError("Rigidbody component not found on the player object.");
        }
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)

        if (rb.linearVelocity.y < 0) { // Check if the player is falling
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallForce - 1) * Time.deltaTime; // Apply fall force to the player
        } else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump")) {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (smallJumpForce - 1) * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Space)) { // Check if the space key is pressed for rocket jump
            RocketJump(); // Call the RocketJump method
            particles.gameObject.SetActive(true); // Play the particle effect
        }else {
            particles.gameObject.SetActive(false); // Stop the particle effect if space key is not pressed
        }

        if (horizontalInput != 0) {
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y); // Move the player horizontally
            // animator.SetBool("IsRunning", true); // Set the animator parameter to indicate running
        }
        else {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop horizontal movement if no input
            // animator.SetBool("IsRunning", false); // Set the animator parameter to indicate movement
        }
    }

    private void RocketJump() {
        rb.AddForce(rocketJumpForce); // Apply rocket jump force to the player
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            animator.SetBool("IsRunning", true); // Set the animator parameter to indicate not jumping
            animator.SetBool("IsJumping", false); // Set the animator parameter to indicate not jumping
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            animator.SetBool("IsRunning", false); // Set the animator parameter to indicate not jumping
            animator.SetBool("IsJumping", true); // Set the animator parameter to indicate jumping
        }
    }
}
