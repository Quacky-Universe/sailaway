using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : MonoBehaviour
{
    private float CurrentSpeed;

    [Header("Player Inputs")] [SerializeField]
    private float InputX;

    [SerializeField] private float InputY;

    private Rigidbody playerRB;

    [Header("Player Movement Stats")] [SerializeField]
    private float Speed = 2.5f;

    [SerializeField] private float turnSpeed = 15f;

    [SerializeField] private float slowedSpeedTime = 2f;
    private float NormalSpeed;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        CurrentSpeed = Speed;
        NormalSpeed = Speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) CurrentSpeed = Speed;

        if (Input.GetKeyDown(KeyCode.Alpha2)) CurrentSpeed = Speed * 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) CurrentSpeed = Speed * 3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) CurrentSpeed = Speed * 4;
        if (Input.GetKeyDown(KeyCode.Alpha5)) CurrentSpeed = Speed * 5;
        if (Input.GetKeyDown(KeyCode.Alpha9)) CurrentSpeed = Speed * 10000000000000000000;
    }

    private void FixedUpdate()
    {
        Debug.Log(CurrentSpeed);
        
        //Detect player input 
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        //Take input and clamp it so the player can't go faster by pressing both diagonal keys at once.
        var MoveDir = new Vector3(InputX, 0.0f, InputY);
        MoveDir = Vector3.ClampMagnitude(MoveDir, 1);


        //Rotate the player based on the moveDir
        if (MoveDir.magnitude > .1f)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MoveDir, Vector3.up), Time.fixedDeltaTime * turnSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDir), turnSpeed * Time.deltaTime);
        } else
        {
            //Stops the player if we press nothing 
            playerRB.velocity = Vector3.zero;
        }
        //Move the player
        playerRB.MovePosition(Vector3.Lerp(transform.position,transform.position + transform.forward * MoveDir.magnitude, CurrentSpeed * Time.deltaTime));
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Island") && slowedSpeedTime > 0)
        {
            slowedSpeedTime -= Time.deltaTime;
            CurrentSpeed = CurrentSpeed / 2;
            playerRB.MovePosition(Vector3.Lerp(transform.position, transform.position + transform.forward * MoveDir.magnitude, (CurrentSpeed * Time.deltaTime)/2));
        }
        if (slowedSpeedTime <= 0)
        {
            CurrentSpeed = NormalSpeed;
            slowedSpeedTime = 2f;
        }
    }*/
}