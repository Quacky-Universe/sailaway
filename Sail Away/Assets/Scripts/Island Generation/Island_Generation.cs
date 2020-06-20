using UnityEngine;

public class Island_Generation : MonoBehaviour
{
    //This also has enemy generation :)
    public GameObject island;
    public int num = 100;

    private Quaternion rotation = new Quaternion(0f,
        0f,
        0f,
        0f);

    public GameObject ship;
    public float xspread = 1000;
    public float yspread;

    public float zspread = 1000;

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0;
            i < num;
            i++)
            SpreadItem();
        SpreadShip(40);
    }

    private void SpreadItem()
    {
        var randposition = new Vector3(Random.Range(-xspread,
                                   xspread),
                               Random.Range(-yspread,
                                   yspread),
                               Random.Range(-zspread,
                                   zspread)) +
                           transform.position;
        if (Physics.CheckSphere(randposition,
            10))
        {
        }
        else
        {
            var clone = Instantiate(island,
                randposition,
                island.transform.localRotation);
        }
    }

    private void SpreadShip(int numb)
    {
        for (var i = 0;
            i < numb;
            i++)
        {
            var randposition = new Vector3(Random.Range(-100,
                                       100),
                                   Random.Range(yspread,
                                       yspread),
                                   Random.Range(-100,
                                       100)) +
                               transform.position;
            var clone = Instantiate(ship,
                randposition,
                island.transform.localRotation);
        }
    }

    // Update is called once per frame
    private float nextActionTime = 0.0f;
    public float period = 30f;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            SpreadShip(2);
            Debug.Log("Added 2 ships :)");
        }
    }
}