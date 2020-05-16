using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    public HealthBar healthBar;
    [SerializeField] private int maxHealth = 20;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0f) Die();
    }

    public virtual void Die()
    {
        //Instantiate Effect

        Destroy(gameObject);
    }
}