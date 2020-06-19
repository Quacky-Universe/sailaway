using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    private readonly int maxHealth = 20;
    private int currentHealth;
    private int hittingIsland;
    public Player_Camera cameraShake;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) TakeDamage(2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Island"))
        {
            hittingIsland = maxHealth / 2;
            TakeDamage(hittingIsland);
            StartCoroutine(cameraShake.Shake(0.1f,0.15f));
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