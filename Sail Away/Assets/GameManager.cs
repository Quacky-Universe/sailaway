using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Transform player;
    public Camera cam;
    public GameObject enemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (enemy != null)
            {
                Instantiate(enemy, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
