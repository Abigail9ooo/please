using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5.0f; // Player movement speed

    [Header("Combat Settings")]
    public GameObject sword;  // Reference to the sword GameObject
    public Animator animator; // Animator for handling animations
    public float attackDamage = 25f; // Damage output of the sword
    public float attackRange = 2f; // Range of the sword attack
    public LayerMask enemyLayer; // Layer on which enemy objects are placed

    [Header("Health Settings")]
    [SerializeField] private float health = 100f; // Player's health

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button for attack
        {
            animator.SetTrigger("Attack");
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Perform a raycast or sphere cast to detect enemies
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, enemyLayer))
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
            {
                // Assuming the enemy has a script called 'EnemyHealth' that manages health
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        // Add logic for player death, such as restarting the level or showing a game over screen
    }
}
