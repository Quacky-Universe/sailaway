using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
public class CrowMovement : MonoBehaviour
{
    Vector3 startPosition;
    [HideInInspector] public Vector3 moveSpot;
    [SerializeField] float speed = 5f;
    bool isFlying = true;

    bool isLeaving = false;

    //Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("Flying", true);

        startPosition = transform.position;
    }

    void Update()
    {
        if (moveSpot != null)
        {
            if (!isLeaving)
            {
                if (transform.position == moveSpot)
                {
                    if (isFlying)
                    {
                        //anim.SetBool("Flying", false);
                        isFlying = false;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

                if (transform.position == startPosition)
                {
                    gameObject.SetActive(false);
                }
            }

            if (Input.anyKeyDown)
            {
                isLeaving = true;
                //anim.SetBool("Flying", true);
            }
        }
    }
}
