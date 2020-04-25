using UnityEngine;

public class Weapons_Projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Island"))
        {
            Destroy(gameObject);
        }
    }   
}
