using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    [Header("Cannon Stats")]
    [SerializeField] Transform weaponPoint;
    [SerializeField] Transform rotatePoint;

    [SerializeField] private string poolTag = "cannon_ball";

    [SerializeField] GameObject cannonBall;

    [SerializeField] float cannonBallSpeed = 250f;

    [SerializeField] float startTimeBTWFires = 2f;
    float timeBTWFires;

    void Start()
    {
        timeBTWFires = startTimeBTWFires;
    }

    void Update()
    {
        Vector3 currentPos = GameManager.instance.cam.WorldToScreenPoint(transform.position);
        Vector2 lookDirection = Input.mousePosition - currentPos;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion weaponPointRotation = Quaternion.AngleAxis(-angle, Vector3.up);

        rotatePoint.rotation = weaponPointRotation;

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
                    cannonBallGO.GetComponent<Rigidbody>().AddForce(rotatePoint.forward * cannonBallSpeed);
                    Destroy(cannonBallGO, 5f);

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
