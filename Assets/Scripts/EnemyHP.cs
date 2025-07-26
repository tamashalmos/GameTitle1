using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    EnemyScript movement;
    void Start()
    {
        currentHealth = maxHealth;
        movement = GetComponent<EnemyScript>();
    }

    public void takeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            movement.enabled = !movement.enabled;
            Die();
        }


    }
    void Die()
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject, 2f);   
        }
}
