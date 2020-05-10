using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalGroupGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject island;
    public float xspread = 20;
    public float yspread = 0;
    public float zspread = 20;
    public int num = 4;
    public Quaternion rotation = new Quaternion(0f,0f,0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num;  i++)
        {
            SpreadIsland();
        }
    }

    void SpreadIsland(){
        Vector3 randposition = new Vector3(Random.Range(-xspread,xspread),Random.Range(-yspread,yspread),Random.Range(-zspread,zspread)) + transform.position;
        GameObject clone = Instantiate(island, randposition, island.transform.localRotation);
    }
    
}

