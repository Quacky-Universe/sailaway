using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiscordPresence;

public class DRPCTEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PresenceManager.UpdatePresence(detail: "yaya");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
