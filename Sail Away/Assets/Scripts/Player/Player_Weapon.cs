using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    [Header("Cannon Stats")]
    [SerializeField] private Transform weaponPoint;

    [SerializeField] private string poolTag = "cannon_ball";

    [SerializeField] GameObject cannonBall;

    [SerializeField] float startTimeBTWFires = 2f;
    float timeBTWFires;

    void Start()
    {
        timeBTWFires = startTimeBTWFires;
    }

    void Update()
    {
        if (timeBTWFires <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                /*
                Gameplay_PoolingManager.Instance.SpawnFromPool(poolTag, weaponPoint.position, weaponPoint.rotation);
                cannonBallGO.transform.position = transform.forward * 50f;
                Destroy(cannonBallGO, 3f);
                */

                if (cannonBall != null)
                {
                    GameObject cannonBallGO = Instantiate(cannonBall, weaponPoint.position, weaponPoint.rotation);
                    cannonBallGO.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                    Destroy(cannonBallGO, 3f);

                    timeBTWFires = startTimeBTWFires;
                }
            }
        }
        else
        {
            timeBTWFires -= Time.deltaTime;
        }
    }
    
}
