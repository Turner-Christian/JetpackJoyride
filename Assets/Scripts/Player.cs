using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem particles;
    public Animator animator;
    public float speed = 5f;
    public float rocketThrust = 15f; // Upward force while holding space
    public float smallJumpForce = 2f;
    public float fallForce = 3.5f;

    private float horizontalInput;
    private bool isRocketThrusting;

    private Rigidbody2D rb;

    private void Start() {
        particles = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        // Check if Space is held
        isRocketThrusting = Input.GetKey(KeyCode.Space);

        RocketBurst(); // Control visual effect
    }

    private void FixedUpdate() {
        // Horizontal movement
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        // Apply upward rocket force while holding Space
        if (isRocketThrusting) {
            rb.AddForce(Vector2.up * rocketThrust);
        }

        // Apply better gravity fall behavior
        if (rb.linearVelocity.y < 0 ) {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallForce - 1) * Time.fixedDeltaTime;
        } else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump")) {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallForce - 1) * Time.fixedDeltaTime;
        }
    }

    private void RocketBurst() {
        // Show or hide thruster particles
        if (isRocketThrusting) {
            if (!particles.isPlaying) {
                particles.Play();
            }
        } else {
            if (particles.isPlaying) {
                particles.Stop();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            animator.SetBool("IsRunning", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            animator.SetBool("IsRunning", false);
        }
    }
}
