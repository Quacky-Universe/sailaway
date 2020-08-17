using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Dolphin : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] AnimationCurve jumpCurve;

    Vector3 jumpDestination;
    [SerializeField] float jumpSpeed = 1.5f;
    [SerializeField] float jumpDistance = 7.5f;

    [SerializeField] Vector3 lerpOffset;

    float currentSpeed = 3f;
    [SerializeField] float normalSpeed = 3f;
    [SerializeField] float fleeSpeed = 6f;

    bool isSwimming = true;

    [SerializeField] float lerpTime = 1.5f;
    float timer = 0f;

    [SerializeField] float radius = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        jumpDestination = new Vector3(transform.position.x, transform.position.y, transform.position.z + jumpDistance);
        lerpOffset = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        StartCoroutine(Jump());
    }

    void Update()
    {
        if (!isSwimming)
        {
            if (timer < lerpTime)
            {
                timer += Time.deltaTime;
            }

            float lerpRatio = timer / lerpTime;

            Vector3 positionOffset = jumpCurve.Evaluate(lerpRatio) * lerpOffset;

            transform.position = Vector3.Lerp(transform.position, jumpDestination, lerpRatio) + positionOffset;

            if (transform.position == jumpDestination)
            {
                StartCoroutine(Jump());
                jumpDestination = new Vector3(transform.position.x, transform.position.y, transform.position.z + jumpDistance);
                lerpOffset = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                isSwimming = true;
            }
        }
    }

    IEnumerator Jump()
    {
        timer = 0f;
        yield return new WaitForSeconds(3f);
        isSwimming = false;
    }
}
