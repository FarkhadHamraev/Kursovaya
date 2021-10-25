using UnityEngine;

public class SavageL2 : MonoBehaviour
{
    public Animator animator;
    private float health;
    private float currentHealth = 5f;

    public void Damage()
    {
        if (currentHealth > 0)
        {
            health = currentHealth - 1f;
            currentHealth = health;
            animator.SetTrigger("GetHit");
            Debug.Log("enemy" + currentHealth);
        }
        else 
        {
            Destroy(gameObject);
            animator.SetTrigger("Dead");
        }
    }
}
