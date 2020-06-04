using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Level : MonoBehaviour
{

    int currentxp;
    int lvlsize;
    int currentlevel;

    public int Lvlsizeincrease;

    public GameObject bar;
    public Text leveltxt;
    void Start()
    {
        lvlsize = Lvlsizeincrease;
        bar.GetComponent<LevelBar>().SetMaxLevel(lvlsize);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentxp >= lvlsize)
        {
            currentlevel++;
            leveltxt.text = "Level " + currentlevel;
            currentxp = 0;
            lvlsize = (currentlevel+1)*Lvlsizeincrease;
            bar.GetComponent<LevelBar>().SetMaxLevel(lvlsize);
        }
        bar.GetComponent<LevelBar>().setLevel(currentxp);
        
       
    }

    public void AddToXP(int xp)
    {
        currentxp = xp + currentxp;
    }
}
