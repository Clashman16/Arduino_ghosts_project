using System.Linq;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public int currentGhost;
    public int rogue;
    public bool haveToChangeRogue;
    public int countDead;
    private int maxGhost;
    public float minGhost;
    private GameObject aGhost;
    private float currentTime;
    public float waitToSpawn;

    private int spawnX;
    private int spawnY;

    void Start()
    {
        countDead = 0;
        currentTime = 0f;
        rogue = 1;
        maxGhost = 2;
        haveToChangeRogue = false;
    }

    public void AddMinGhostValue()
    {
        minGhost += Random.Range(0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(countDead %5 == 0 && haveToChangeRogue == true)
        {
            rogue += 1;
            if(maxGhost < 6)
            {
                maxGhost += 1;
            }

            haveToChangeRogue = false;
        }

        string ghostName = "Prefab/Ghost_Slime";

        if (rogue > 1)
        {
            int nbSlimes = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name.Contains("Ghost_Slime")).Count();

            if (nbSlimes >= currentGhost / 2)
            {
                ghostName = "Prefab/Ghost_Demon";
            }
        }
        else if (rogue > 3)
        {
            int nbDemons = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name.Contains("Ghost_Demon")).Count();

            if (nbDemons >= currentGhost / 2)
            {
                ghostName = "Prefab/Ghost_Genie";
            }
        }

        aGhost = Resources.Load<GameObject>(ghostName);

        if (currentGhost < (int) minGhost && currentTime < 0 && currentGhost <= maxGhost)
        {
            spawnX = Random.Range(0, 1920);
            if(spawnX > 600 && spawnX < 1300)
            {
                do
                {
                    spawnY = Random.Range(0, 1050);
                } while (spawnY > 250 && spawnY < 850);
            }
            Instantiate(aGhost, new Vector3(spawnX, spawnY, 0), transform.rotation);
            currentGhost += 1; 
            if (minGhost > 11)
            {
                waitToSpawn = waitToSpawn*10/minGhost;
                Debug.Log(waitToSpawn + "\n");
                if(waitToSpawn < 0.55f)
                {
                    waitToSpawn = 0.55f;
                }
            }
            currentTime = waitToSpawn;
        }
        currentTime -= Time.deltaTime;
    }
}
