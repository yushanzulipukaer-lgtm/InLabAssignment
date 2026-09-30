using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Transform player;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnDistance = 10f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnEnemy();

            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        float angle = Random.Range(0f, 360f);

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        Vector2 spawnPosition = (Vector2)player.position + direction * spawnDistance;

        enemyFactory.CreateEnemy(spawnPosition);
    }
}
