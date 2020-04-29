using UnityEngine;

public class Weapons_Projectile : MonoBehaviour
{
    public static float damage = 10f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (collision.transform.GetComponent<CharacterHealth>() != null)
            {
                CharacterHealth characterHealth = collision.transform.GetComponent<CharacterHealth>();
                characterHealth.TakeDamage(damage);

                Destroy(gameObject);
            }
        }
        else if (collision.transform.CompareTag("Island"))
        {
            Destroy(gameObject);
        }
    }   
}
