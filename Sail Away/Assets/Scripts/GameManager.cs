using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Camera cam;
    public GameObject enemy;

    public Transform player;

    public Transform interactUI;
}
