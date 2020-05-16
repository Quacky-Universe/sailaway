using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Cannon Stats")] [SerializeField]
    Transform weaponPoint;

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


        if (timeBTWFires <= 0f)
        {
            if (cannonBall != null)
            {
                GameObject cannonBallGO = Instantiate(cannonBall, weaponPoint.position, weaponPoint.rotation);
                cannonBallGO.GetComponent<Rigidbody>().AddForce(rotatePoint.forward * cannonBallSpeed);
                Destroy(cannonBallGO, 5f);

                timeBTWFires = startTimeBTWFires;
            }
        }
        else
        {
            timeBTWFires -= Time.deltaTime;
        }
    }
}