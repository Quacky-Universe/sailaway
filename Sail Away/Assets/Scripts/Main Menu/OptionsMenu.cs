using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{ 
    public GameObject player;

    // Start is called before the first frame update
    public AudioMixer MainVolume;
    public void SetVolume(float volume)
    {
        MainVolume.SetFloat("MainVolume", volume);
    }

    public void SetGraphics(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    
}
