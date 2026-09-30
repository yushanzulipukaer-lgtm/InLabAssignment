using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float damage = 10f;

    private float currentHealth;

    private Transform player;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        Vector2 direction = ((Vector2)player.position - rb.position).normalized;

        Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerHealth health = collision.GetComponent<PlayerHealth>();

        if(health != null)
            health.TakeDamage(damage);

        Destroy(gameObject);
    }
}
