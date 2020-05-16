using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall;

    [SerializeField] private float cannonBallSpeed = 250f;

    [SerializeField] private string poolTag = "cannon_ball";

    [SerializeField] private Transform rotatePoint;

    [SerializeField] private float startTimeBTWFires = 2f;

    private float timeBTWFires;

    // Start is called before the first frame update
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


        if (timeBTWFires <= 0f)
        {
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