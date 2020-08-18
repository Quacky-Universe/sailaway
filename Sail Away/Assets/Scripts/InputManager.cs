using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public KeyCode m_Forward_Key { get; set; }
    public KeyCode m_Backwards_Key { get; set; }
    public KeyCode m_Right_Key { get; set; }
    public KeyCode m_Left_Key { get; set; }
    public KeyCode c_Shoot_Key { get; set; }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_Forward_Key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("m_Forward_Key", "W"));
        m_Backwards_Key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("m_Backwards_Key", "S"));
        m_Right_Key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("m_Right_Key", "D"));
        m_Left_Key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("m_Left_Key", "A"));
        c_Shoot_Key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("c_Shoot_Key", "Left Mouse Button"));
    }
}
