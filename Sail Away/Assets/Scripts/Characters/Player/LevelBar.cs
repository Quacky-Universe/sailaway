using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Image fill;
    public Gradient gradient;
    public GameObject Healthbar;
    public Slider slider;

    public void SetMaxLevel(int lvlsize)
    {
        slider.maxValue = lvlsize;
        slider.value = lvlsize;

        fill.color = gradient.Evaluate(1f);
    }

    public void setLevel(int currentxp)
    {
        slider.value = currentxp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
