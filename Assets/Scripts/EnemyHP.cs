using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
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
            Die();
        }

        void Die()
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject, 2f);   
        }
    }
}
