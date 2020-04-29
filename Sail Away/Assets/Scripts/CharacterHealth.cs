using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 20f;
    [SerializeField] float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Instantiate Effect

        Destroy(gameObject);
    }
}
