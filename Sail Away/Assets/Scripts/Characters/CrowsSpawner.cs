using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowsSpawner : MonoBehaviour
{
    float afkTime = 0f;
    public float crowStartTime = 30f;

    bool crowHasSpawned = false;

    [SerializeField] LayerMask layerMask;

    int crowCount = 0;

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
                crowCount = 0;
                StopAllCoroutines();
            }
        }

        if (crowCount >= 5)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnCrow()
    {
        crowHasSpawned = false;
        transform.localPosition = new Vector3(Random.Range(-0.375f, 0.375f), 2f, Random.Range(-0.225f, 0.5f));

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, layerMask))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(transform.parent.position.x - 10f, transform.parent.position.x + 10f), 
                                                        transform.parent.position.y + 10f, 
                                                        Random.Range(transform.parent.position.z - 10f, transform.parent.position.z + 10f));
            Debug.Log("RandomSpawnPoint:" + randomSpawnPosition);
            CrowMovement crowObject = ObjectPooler.instance.SpawnFromPool("Crow", randomSpawnPosition, Quaternion.identity).GetComponent<CrowMovement>();
            crowCount++;
            crowObject.moveSpot = hit.point;
            crowHasSpawned = true;
            if (crowCount < 5)
            {
                yield return new WaitForSeconds(Random.Range(10f, 16f));
                yield return StartCoroutine(SpawnCrow());
            }
        }
        else
        {
            yield return StartCoroutine(SpawnCrow());
        }
    }
}
