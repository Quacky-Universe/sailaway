using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    public Transform target;

    Vector3 moveSpot;
    Vector3 centerPosition;

    float currentSpeed = 3f;
    [SerializeField] float normalSpeed = 3f;
    [SerializeField] float fastSpeed = 5f;

    [SerializeField] float rotationSpeed = 30f;

    public bool isPlayer = false;
    [SerializeField] float radius = 20f;

    void Start()
    {
        if (isPlayer)
        {
            target = GameManager.instance.player;
        }

        centerPosition = new Vector3(target.position.x, target.position.y + 5f, target.position.z);
        moveSpot = new Vector3(Random.Range(centerPosition.x - 5f, centerPosition.x + 5f), 5f, Random.Range(centerPosition.z - 5f, centerPosition.z + 5f));
    }

    void Update()
    {
        if (isPlayer)
        {
            float distanceFromPlayer = (transform.position - target.position).sqrMagnitude;

            if (distanceFromPlayer <= radius * radius)
            {
                if (currentSpeed != normalSpeed)
                {
                    currentSpeed = normalSpeed;
                }

                float distanceFromMoveSpot = (transform.position - moveSpot).sqrMagnitude;

                if (distanceFromMoveSpot > 0.04f)
                {
                    Vector3 direction = moveSpot - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                }
                else
                {
                    moveSpot = new Vector3(Random.Range(centerPosition.x - 5f, centerPosition.x + 5f), 5f, Random.Range(centerPosition.z - 5f, centerPosition.z + 5f));
                }
            }
            else
            {
                if (currentSpeed != fastSpeed)
                {
                    currentSpeed = fastSpeed;
                }

                centerPosition = new Vector3(target.position.x, target.position.y + 5f, target.position.z);
                moveSpot = centerPosition;

                Vector3 direction = new Vector3(target.position.x, target.position.y + 5f, target.position.z) - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
