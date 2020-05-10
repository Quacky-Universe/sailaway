using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : MonoBehaviour
{
    [Header("Player Movement Stats")]
    [SerializeField] private float Speed = 2.5f;
    [SerializeField] private float turnSpeed = 15f;

    [Header("Player Inputs")]
    [SerializeField]private float InputX;
    [SerializeField] private float InputY;

    Rigidbody playerRB;
    private float CurrentSpeed;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        CurrentSpeed = Speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentSpeed = Speed;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentSpeed = Speed * 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentSpeed = Speed * 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    CurrentSpeed = Speed * 4;
                }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CurrentSpeed = Speed * 5;
        }
    }
    private void FixedUpdate()
    {
        //Detect player input 
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        //Take input and clamp it so the player can't go faster by pressing both diagonal keys at once.
        Vector3 MoveDir = new Vector3(InputX, 0.0f, InputY);
        MoveDir = Vector3.ClampMagnitude(MoveDir, 1);


        //Rotate the player based on the moveDir
        if (MoveDir.magnitude > .1f)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MoveDir, Vector3.up), Time.fixedDeltaTime * turnSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDir), turnSpeed * Time.deltaTime);
        }
        else
        {
            //Stops the player if we press nothing 
            playerRB.velocity = Vector3.zero;
        }

        //Move the player
        playerRB.MovePosition(Vector3.Lerp(transform.position, transform.position + transform.forward * MoveDir.magnitude, CurrentSpeed * Time.deltaTime));
    }
}
