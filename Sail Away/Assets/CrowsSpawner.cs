using System.Collections;
using UnityEngine;

public class CrowsSpawner : MonoBehaviour
{
    float afkTime = 0f;
    public float crowStartTime = 30f;

    bool crowHasSpawned = false;

    [SerializeField] LayerMask layerMask;

    void Update()
    {
        if (!Input.anyKeyDown)
        {
            afkTime += Time.deltaTime;

            if (afkTime >= crowStartTime && !crowHasSpawned)
            {
                StartCoroutine(SpawnCrow());
            }
        }
        else
        {
            if (afkTime >= 0f)
            {
                afkTime = 0f;
                StopAllCoroutines();
            }
        }
    }

    IEnumerator SpawnCrow()
    {
        crowHasSpawned = false;
        transform.localPosition = new Vector3(Random.Range(-5f, 5f), 10f, Random.Range(-5f, 5f));

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, layerMask))
        {
            //TODO: Spawn crow
            Debug.Log("Crow spawned");
            crowHasSpawned = true;
            yield return new WaitForSeconds(Random.Range(10f, 16f));
            yield return StartCoroutine(SpawnCrow());
        }
        else
        {
            yield return StartCoroutine(SpawnCrow());
        }
    }
}
