using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    //Transform target;
    //[SerializeField] float range = 5f;

    [SerializeField] float speed = 2f;
    [SerializeField] float rotationSpeed = 10f;

    Vector3 startPosition;
    Vector3 moveSpot;

    void Start()
    {
        startPosition = transform.position;

        //target = GameManager.instance.player;
    }

    void Update()
    {
        /*
        float distanceFromPlayer = (transform.position - target.position).sqrMagnitude;

        if (distanceFromPlayer <= range * range)
        {
            //Make fish run away
        }
        */

        float distanceFromMoveSpot = (transform.position - moveSpot).sqrMagnitude;

        if (distanceFromMoveSpot <= 0.04f)
        {
            moveSpot = new Vector3(Random.Range(startPosition.x - 5f, startPosition.x + 5f), -2f, Random.Range(startPosition.z - 5f, startPosition.z + 5f));
        }
        else
        {
            Vector3 direction = moveSpot - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
