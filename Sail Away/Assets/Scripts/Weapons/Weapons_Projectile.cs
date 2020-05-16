using UnityEngine;

public class Weapons_Projectile : MonoBehaviour
{
    private static readonly int damage = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<CharacterHealth>() != null)
            {
                var characterHealth = collision.transform.GetComponent<CharacterHealth>();
                characterHealth.TakeDamage(damage);

                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.name != null)
        {
            Destroy(gameObject);
        }
    }
}