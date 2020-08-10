using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Dolphin : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform graphics;

    [SerializeField] float radius = 5f;
    bool isSwimming = false;
    bool isJumping = false;

    public bool finishedJump = false;

    Vector2 centerPosition;
    Vector3 moveSpotPosition;

    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //Get center position of movement area
        centerPosition = transform.position;
        //Get random position inside the movement area
        moveSpotPosition = new Vector3(Random.Range(centerPosition.x - 5f, centerPosition.x + 5f), 0f, Random.Range(centerPosition.y - 5f, centerPosition.y + 5f));
        //Move the agent towards that random position
        //agent.SetDestination(moveSpotPosition);

        //Start Animation Cycle
        //anim.SetBool("Swimming", true);
        StartCoroutine(AnimationCycle());

        Debug.Log(graphics.name);
    }

    void Update()
    {
        /*
        //Get distance from Player
        float distanceFromPlayer = (GameManager.instance.player.position - transform.position).sqrMagnitude;

        //Check if the distance from Player is lower than the radius
        if (distanceFromPlayer <= radius * radius)
        {
            //TODO: Move towards nearest island
            //Set the swimming/guiding the player state to false
            isSwimming = true;
        }
        else
        {
            if (isSwimming)
            {
                //Stop Animation Cycle
                StopAllCoroutines();
                //Get center position of movement area
                centerPosition = transform.position;
                //Get random position inside the movement area
                moveSpotPosition = new Vector3(Random.Range(centerPosition.x - 5f, centerPosition.x + 5f), 0f, Random.Range(centerPosition.y - 5f, centerPosition.y + 5f));
                //Move the agent towards that random position
                agent.SetDestination(moveSpotPosition);
                //Set the swimming/guiding the player state to false
                isSwimming = false;
            }
        }

        //Get distance from Move Spot Position
        float distanceFromMoveSpotPosition = (moveSpotPosition - transform.position).sqrMagnitude;

        //Check if distance from Move Spot Position is lower than 0.2
        if (distanceFromMoveSpotPosition <= 0.04f)
        {
            //Get random position inside the movement area
            moveSpotPosition = new Vector3(Random.Range(centerPosition.x - 5f, centerPosition.x + 5f), 0f, Random.Range(centerPosition.y - 5f, centerPosition.y + 5f));
            //Move the agent towards that random position
            agent.SetDestination(moveSpotPosition);
        }
        */

        if (isJumping && finishedJump)
        {
            SetPositions();
        }
    }

    IEnumerator AnimationCycle()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        isJumping = true;
        //agent.speed = 0f;
        anim.SetTrigger("Jump");
    }

    public void SetPositions()
    {
        transform.position = new Vector3(graphics.position.x, 0f, graphics.position.z);
        graphics.localPosition = new Vector3(transform.position.x, -1f, transform.position.z);
        StartCoroutine(AnimationCycle());
        finishedJump = false;
        isJumping = false;
    }
}
