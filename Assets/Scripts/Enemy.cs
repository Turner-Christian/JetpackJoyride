using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    private float randSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomSpeed();
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
            Destroy(gameObject);
        }
    }
}
