using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private GameObject explosionPrefab; // Reference to the explosion prefab
    [SerializeField]
    private Shake cameraShake; // Reference to the camera shake script
    private float randSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomSpeed();
        cameraShake = Camera.main.GetComponent<Shake>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(randSpeed, 0);
    }

    private void RandomSpeed()
    {
        randSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("BorderLeft"))
        {
            Destroy(gameObject); // Destroy the enemy object when it collides with the left border
        }
        if(other.gameObject.CompareTag("Player"))
        {
            if (cameraShake != null){
                cameraShake.start = true;
            }
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Instantiate explosion prefab at the enemy's position
            Destroy(other.gameObject); // Destroy the player object
            Destroy(gameObject);
            GmeManager.PlayerIsDead = true; // Set the player dead flag to true
        }
    }
}
