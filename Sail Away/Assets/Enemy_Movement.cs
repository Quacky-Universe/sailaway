﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 1f;
    public float turnSpeed = 0.5f;

    public Vector3 mainPosition;
    public Vector3 moveToPosition;

    public float attackRadius = 5f;
    public float fleeRadius = 10f;

    bool isAttacking = false;

    void Start()
    {
        //Random Positions to patrol to
        mainPosition = transform.position;
        moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y, Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
    }

    void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, GameManager.instance.player.position);

        if (distanceFromTarget <= attackRadius && distanceFromTarget <= fleeRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.position, speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.instance.player.position - transform.position), turnSpeed * Time.deltaTime);

            isAttacking = true;
        }
        else if (distanceFromTarget >= attackRadius && distanceFromTarget <= fleeRadius && isAttacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.position, speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.instance.player.position - transform.position), turnSpeed * Time.deltaTime);
        }
        else if (distanceFromTarget >= attackRadius && distanceFromTarget >= fleeRadius && isAttacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPosition, speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveToPosition - transform.position), turnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveToPosition) <= 0.02f)
            {
                moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y, Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
            }

            isAttacking = false;
        }
        else if (distanceFromTarget >= attackRadius && distanceFromTarget >= fleeRadius && !isAttacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPosition, speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveToPosition - transform.position), turnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveToPosition) <= 0.02f)
            {
                moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y, Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
            }
        }
        else if (distanceFromTarget >= attackRadius && distanceFromTarget <= fleeRadius && !isAttacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPosition, speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveToPosition - transform.position), turnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveToPosition) <= 0.02f)
            {
                moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y, Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fleeRadius);
    }
}

/*
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_Movement : MonoBehaviour
{
    NavMeshAgent agent;

    public Vector3 mainPosition;
    public Vector3 moveToPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Random Positions to patrol to
        mainPosition = transform.position;
        moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y, Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
    }

    void Update()
    {
        agent.Move(moveToPosition);

        if (Vector3.Distance(transform.position, moveToPosition) <= 0.02f)
        {
            moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y, Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
        }
    }
}
*/
