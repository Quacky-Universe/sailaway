using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    public GameObject enemy;

    public Transform player;

    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
}