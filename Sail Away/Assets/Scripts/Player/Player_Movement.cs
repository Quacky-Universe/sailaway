using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Player Movement Stats")]
    [SerializeField] private float Speed;
    [SerializeField] private float turnSpeed = 15f;

    [Header("Player Inputs")]
    [SerializeField]private float InputX;
    [SerializeField] private float InputY;

    public Rigidbody playerRB;

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
        playerRB.MovePosition(Vector3.Lerp(transform.position, transform.position + transform.forward * MoveDir.magnitude, Speed * Time.deltaTime));
    }
}