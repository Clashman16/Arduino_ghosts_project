using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public int currentGhost;
    public int rogue;
    public int maxGhost;
    public float minGhost;
    private GameObject aGhost;
    private float currentTime;
    public float waitToSpawn;

    private int spawnX;
    private int spawnY;

    void Start()
    {
        currentTime = 0f;
        rogue = 0;
        maxGhost = 3;
    }

    public void AddMinGhostValue()
    {
        minGhost += Random.Range(0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGhost < 3 )
        {
            rogue += 1;
            maxGhost += 3;
        }

        string ghostName = "";

        if (rogue % 2 != 0)
        {
            if (currentGhost % 2 == 0)
            {
                ghostName = "Prefab/Ghost_Slime";
            }
            else
            {
                ghostName = "Prefab/Ghost_Demon";
            }
        }
        else
        {
            if (currentGhost % 2 != 0)
            {
                ghostName = "Prefab/Ghost_Slime";
            }
            else
            {
                ghostName = "Prefab/Ghost_Demon";
            }
        }

        aGhost = Resources.Load<GameObject>(ghostName);

        if (currentGhost <  (int) minGhost && currentTime < 0 && currentGhost <= maxGhost)
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
