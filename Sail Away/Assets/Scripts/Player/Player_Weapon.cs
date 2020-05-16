using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall;

    [SerializeField] private float cannonBallSpeed = 250f;

    [SerializeField] private string poolTag = "cannon_ball";
    [SerializeField] private Transform rotatePoint;

    [SerializeField] private float startTimeBTWFires = 2f;
    private float timeBTWFires;

    [Header("Cannon Stats")] [SerializeField]
    private Transform weaponPoint;

    private void Start()
    {
        timeBTWFires = startTimeBTWFires;
    }

    private void Update()
    {
        var currentPos = GameManager.instance.cam.WorldToScreenPoint(transform.position);
        Vector2 lookDirection = Input.mousePosition - currentPos;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        var weaponPointRotation = Quaternion.AngleAxis(-angle, Vector3.up);

        rotatePoint.rotation = weaponPointRotation;

        if (timeBTWFires <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
                /*
                    Gameplay_PoolingManager.Instance.SpawnFromPool(poolTag, weaponPoint.position, weaponPoint.rotation);
                    cannonBallGO.transform.position = transform.forward * 50f;
                    Destroy(cannonBallGO, 3f);
                    */

                if (cannonBall != null)
                {
                    var cannonBallGO = Instantiate(cannonBall, weaponPoint.position, weaponPoint.rotation);
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