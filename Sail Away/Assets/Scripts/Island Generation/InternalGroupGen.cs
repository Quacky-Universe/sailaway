using UnityEngine;

public class InternalGroupGen : MonoBehaviour
{
    public GameObject Dessert1;
    public GameObject Dessert2;
    public GameObject Dessert3;
    public GameObject Dessert4;
    public GameObject Dessert5;
    public GameObject Grass1;
    public GameObject Grass2;
    public GameObject Grass3;
    public GameObject Grass4;
    public GameObject Ice1;
    private GameObject island;
    private int islandnum;
    public int num = 4;
    private Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
    public float xspread = 20;
    public float yspread;

    public float zspread = 20;

    // Start is called before the first frame update
    private void Start()
    {
        var biome = Random.Range(1, 3);
        switch (biome)
        {
            case 1:
                for (var i = 0; i < num; i++) SpreadIsland(1);
                break;
            case 2:
                for (var i = 0; i < num; i++) SpreadIsland(2);
                break;
            case 3:
                for (var i = 0; i < num; i++) SpreadIsland(3);
                break;
        }
    }

    private void SpreadIsland(int biomechoosen)
    {
        switch (biomechoosen)
        {
            case 1:
                islandnum = Random.Range(0, 5);
                switch (islandnum)
                {
                    case 1:
                        island = Dessert1;
                        break;
                    case 2:
                        island = Dessert2;
                        break;
                    case 3:
                        island = Dessert3;
                        break;
                    case 4:
                        island = Dessert4;
                        break;
                    case 5:
                        island = Dessert5;
                        break;
                }

                var randpositiondesert = new Vector3(Random.Range(-xspread, xspread), Random.Range(-yspread, yspread),
                    Random.Range(-zspread, zspread)) + transform.position;
                if (Physics.CheckSphere(randpositiondesert, 5))
                {
                }
                else
                {
                    var clone = Instantiate(island, randpositiondesert, island.transform.localRotation);
                    //Quaternion randrotation = new Quaternion(-89.98f,Random.Range(-360f,360f),0f,0f);
                    //clone.transform.rotation = randrotation;
                }

                break;
            case 2:
                islandnum = Random.Range(6, 9);
                switch (islandnum)
                {
                    case 6:
                        island = Grass1;
                        break;
                    case 7:
                        island = Grass2;
                        break;
                    case 8:
                        island = Grass3;
                        break;
                    case 9:
                        island = Grass4;
                        break;
                }

                var randpositiongrass = new Vector3(Random.Range(-xspread, xspread), Random.Range(-yspread, yspread),
                    Random.Range(-zspread, zspread)) + transform.position;
                if (Physics.CheckSphere(randpositiongrass, 5))
                {
                }
                else
                {
                    var clone = Instantiate(island, randpositiongrass, island.transform.localRotation);
                }

                break;
            case 3:
                island = Ice1;
                var randpositionice = new Vector3(Random.Range(-xspread, xspread), Random.Range(-yspread, yspread),
                    Random.Range(-zspread, zspread)) + transform.position;
                if (Physics.CheckSphere(randpositionice, 5))
                {
                }
                else
                {
                    var clone = Instantiate(island, randpositionice, island.transform.localRotation);
                }

                break;
        }
    }
}