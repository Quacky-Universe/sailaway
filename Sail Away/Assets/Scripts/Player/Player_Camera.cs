using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private Transform target;

    private void Start()
    {
        //Find the player transform
        target = GameManager.instance.player;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}