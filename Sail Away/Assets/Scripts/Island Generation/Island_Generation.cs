using UnityEngine;

public class Island_Generation : MonoBehaviour
{
    public GameObject island;
    public int num = 100;
    public Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
    public GameObject ship;
    public float xspread = 1000;
    public float yspread;

    public float zspread = 1000;

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < num; i++) SpreadItem();
        for (var i = 0; i < 20; i++) SpreadShip();
    }

    private void SpreadItem()
    {
        var randposition = new Vector3(Random.Range(-xspread, xspread), Random.Range(-yspread, yspread),
            Random.Range(-zspread, zspread)) + transform.position;
        var clone = Instantiate(island, randposition, island.transform.localRotation);
    }

    private void SpreadShip()
    {
        var randposition = new Vector3(Random.Range(-30, 30), Random.Range(-yspread, yspread), Random.Range(-30, 30)) +
                           transform.position;
        var clone = Instantiate(ship, randposition, island.transform.localRotation);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}