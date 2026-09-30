using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    public Enemy CreateEnemy(Vector2 spawnPosition)
    {
        Enemy newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        return newEnemy;
    }
}
