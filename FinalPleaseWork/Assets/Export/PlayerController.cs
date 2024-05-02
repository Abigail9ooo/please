using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5.0f; // Player movement speed

    [Header("Combat Settings")]
    public GameObject sword;  // Reference to the sword GameObject
    public Animator animator; // Animator for handling animations
    public float attackDamage = 25f; // Damage output of the sword
    public float attackRange = 2f; // Range of the sword attack

    [Header("Health Settings")]
    [SerializeField] private float health = 100f; // Player's health

    public float Health // Property to access and modify player's health
    {
        get { return health; }
        set
        {
            health = value;
            Debug.Log($"Health: {health}");
            if (health <= 0)
            {
                Die();
            }
        }
    }

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

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button for attack
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack"); // Ensure there is an "Attack" trigger set in your Animator
            }

            Attack();
        }
    }

    private void Attack()
    {
        // Detect enemies within range of the attack
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, attackRange, transform.forward, 0f);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                // Assuming enemies have an EnemyHealth script
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage; // Adjust health and check for death in the setter
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        // Example: Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
