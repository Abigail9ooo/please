using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Required for NavMesh

public class EnemyAI : MonoBehaviour
{
    [Header("General Settings")]
    public float health = 100f;
    public float damage = 10f;
    public float moveSpeed = 5f;

    [Header("Shooting Settings")]
    public bool canShoot;
    public float shootingInterval = 2f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    [Header("Explosion Settings")]
    public bool canExplode;
    public float explosionRadius = 5f;
    public GameObject explosionEffect;


    private NavMeshAgent agent;
    private Transform target; // Assuming you want to move towards a target

    private float shootingTimer;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed; // Set NavMeshAgent speed
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player
    }

    void Update()
    {
        if (canShoot)
        {
            HandleShooting();
        }

       

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (target != null)
            agent.SetDestination(target.position); // Set destination to move towards the player
    }

    private void HandleShooting()
    {
        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingInterval)
        {
            shootingTimer = 0;
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        if (projectilePrefab && projectileSpawnPoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            if (projectileScript)
            {
                projectileScript.SetSpeed(10f); // example speed
                projectileScript.SetDamage(damage);
            }
        }
    }

   

    // All other methods remain unchanged
}
