using System.Collections;
using System.Collections.Generic;
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

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        Debug.Log(duration);
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.4f, 0.4f) * magnitude;
            float y = Random.Range(-0.4f, 0.4f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }
}