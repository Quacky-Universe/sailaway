using DiscordPresence;
using UnityEngine;

public class DRPCTEST : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PresenceManager.UpdatePresence("yaya");
    }

    // Update is called once per frame
    private void Update()
    {
    }
}