using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    [Header("Cannon Stats")]
    [SerializeField] private Transform weaponPoint;

    [SerializeField] private string poolTag = "cannon_ball";

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Gameplay_PoolingManager.Instance.SpawnFromPool(poolTag, weaponPoint.position, weaponPoint.rotation);
        }
    }
}
