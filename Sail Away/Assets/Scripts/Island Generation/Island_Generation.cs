using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_Generation : MonoBehaviour
{

    public GameObject island;
    public float xspread = 1000;
    public float yspread = 0;
    public float zspread = 1000;
    public int num = 100;
    public Quaternion rotation = new Quaternion(0f,0f,0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num;  i++)
        {
            SpreadItem();

        }
    }

    void SpreadItem(){
        Vector3 randposition = new Vector3(Random.Range(-xspread,xspread),Random.Range(-yspread,yspread),Random.Range(-zspread,zspread)) + transform.position;
        GameObject clone = Instantiate(island, randposition,island.transform.localRotation );
        //clone.transform.position.y = island.transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
