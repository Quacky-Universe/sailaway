using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : CharacterHealth
{
    int maxHealth = 20;
    int currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(2);
        }
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
