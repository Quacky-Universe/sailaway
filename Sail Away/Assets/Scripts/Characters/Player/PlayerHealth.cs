using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    private readonly int maxHealth = 20;
    private int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) TakeDamage(2);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0f)
        {
        }
    }
}