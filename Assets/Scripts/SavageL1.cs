using UnityEngine;

public class SavageL1 : MonoBehaviour
{
    public Animator animator;
    private float health;
    private float currentHealth = 4f;
    int count;

    void Start()
    {
        count = PlayerPrefs.GetInt("count");
    }

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
