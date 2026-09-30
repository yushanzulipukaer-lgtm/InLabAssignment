using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifeTime = 3f;

    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    public void Initialize(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    private void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
