using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefeb;
    [SerializeField] private int poolSize = 40;

    private List<Projectile> projectiles = new List<Projectile>();

    private void Start()
    {
        for(int i = 0; i < poolSize; i++)
            {
                CreateProjectiles();
            }
    }

    private Projectile CreateProjectiles()
    {
        Projectile projectile = Instantiate(projectilePrefeb, transform);
        projectile.gameObject.SetActive(false);
        projectiles.Add(projectile);

        return projectile;
    }

    public Projectile GetProjectile(Vector2 position)
    {
        foreach(Projectile projectile in projectiles)
        {
            if(!projectile.gameObject.activeSelf)
            {
                projectile.transform.position = position;
                projectile.gameObject.SetActive(true);
                return projectile;
            }
        }

        //create another one if the pool is empty because every bullet was shot;
        Projectile newProjectile = CreateProjectiles();
        newProjectile.transform.position = position;
        newProjectile.gameObject.SetActive(true);
        return newProjectile;
    }
}
