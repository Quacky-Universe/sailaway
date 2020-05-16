using UnityEngine;

public class InternalGroupGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject island;
    public int num = 4;
    public Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
    public float xspread = 20;
    public float yspread;

    public float zspread = 20;

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < num; i++) SpreadIsland();
    }

    private void SpreadIsland()
    {
        var randposition = new Vector3(Random.Range(-xspread, xspread), Random.Range(-yspread, yspread),
            Random.Range(-zspread, zspread)) + transform.position;
        var clone = Instantiate(island, randposition, island.transform.localRotation);
    }
}