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

        //mozgás leállítása 1mpre
        StartCoroutine(TemporarilyDisableMovement(0.5f));

        if (currentHealth <= 0)
        {
            movement.enabled = false;
            Die();
        }


    }
    void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, 2f);
    }

    private System.Collections.IEnumerator TemporarilyDisableMovement(float duration)
    {
        movement.enabled = false;
        yield return new WaitForSeconds(duration);

        if (currentHealth > 0)
        {
            movement.enabled = true;
        }  
     }
}
