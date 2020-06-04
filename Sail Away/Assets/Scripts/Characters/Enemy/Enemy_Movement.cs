using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy_Movement : MonoBehaviour
{
    public float attackRadius = 5f;
    public float fleeRadius = 10f;

    private RaycastHit hit;

    private bool isAttacking;

    public Vector3 mainPosition;
    public Vector3 moveToPosition;

    public LayerMask obstruct;
    private Rigidbody rb;

    public float speed = 200f;
    public float turnSpeed = 0.25f;
    public bool nearplayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Random Positions to patrol to
        mainPosition = transform.position;
        moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y,
            Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
    }

    void Update()
    {
        var distanceFromTarget = Vector3.Distance(transform.position, GameManager.instance.player.position);

            if (isAttacking)
            {
                if (Physics.Raycast(transform.position, GameManager.instance.player.position - transform.position,
                    out hit,
                    fleeRadius))
                {
                    if (hit.transform == GameManager.instance.player)
                    {
                        rb.velocity = transform.forward * speed * Time.deltaTime;

                        transform.rotation = Quaternion.Slerp(transform.rotation,
                            Quaternion.LookRotation(GameManager.instance.player.position - transform.position),
                            turnSpeed * Time.deltaTime);
                    }
                    else
                    {
                        isAttacking = false;
                    }
                }

                if (distanceFromTarget >= attackRadius && distanceFromTarget >= fleeRadius) isAttacking = false;
            }

            if (Physics.Raycast(transform.position, GameManager.instance.player.position - transform.position, out hit,
                fleeRadius))
            {
                if (hit.transform == GameManager.instance.player)
                {
                    if (distanceFromTarget <= attackRadius && distanceFromTarget <= fleeRadius) isAttacking = true;
                }
                else
                {
                    isAttacking = false;
                }
            }

            if (isAttacking)
            {
                rb.velocity = transform.forward * speed * Time.deltaTime;

                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(GameManager.instance.player.position - transform.position),
                    turnSpeed * Time.deltaTime);
            }
            else
            {
                rb.velocity = transform.forward * speed * Time.deltaTime;

                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(moveToPosition - transform.position), turnSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, moveToPosition) <= 0.02f)
                    moveToPosition = new Vector3(Random.Range(mainPosition.x - 5f, mainPosition.x + 5f), mainPosition.y,
                        Random.Range(mainPosition.z - 5f, mainPosition.z + 5f));
         
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fleeRadius);

        if (Physics.Raycast(transform.position, GameManager.instance.player.position - transform.position, out hit,
            fleeRadius))
        {
            if (hit.transform == GameManager.instance.player)
            {
                if (isAttacking)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.green;

                Gizmos.DrawLine(transform.position, GameManager.instance.player.position);
            }
            else
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, GameManager.instance.player.position);
            }
        }
    }
}
