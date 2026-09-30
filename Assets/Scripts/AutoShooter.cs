using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireInterval = 1f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            Enemy target = FindClosestEnemy();

            if (target != null)
                Fire(target);

            timer = 0f;
        }
    }

    private Enemy FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Enemy closestEnemy = null;

        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemyObject in enemies)
        {
            float distance = Vector2.Distance(transform.position,enemyObject.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;

                closestEnemy = enemyObject.GetComponent<Enemy>();
            }
        }

        return closestEnemy;
    }

    private void Fire(Enemy target)
    {
        Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;

        Projectile projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        Vector2 direction = target.transform.position - transform.position;

        projectile.Initialize(direction);
    }
}
