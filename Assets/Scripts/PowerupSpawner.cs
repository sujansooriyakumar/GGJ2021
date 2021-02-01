using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public Transform[] spawns;
    bool[] spawned;
    public float totalTime;
    public GameObject[] powerups;
    int powerupCount = 7;
    // Start is called before the first frame update
    void Start()
    {
        spawned = new bool[spawns.Length];
        for (int i = 0; i < spawns.Length; i++)
        {
            spawned[i] = false;
        }
        int spawnedCount = 0;
        while (spawnedCount <= powerupCount)
        {
            int spawnLoc = Random.Range(0, spawns.Length);
            if (spawned[spawnLoc] == false)
            {
                Instantiate(powerups[Random.Range(0, powerups.Length)], spawns[spawnLoc].transform.position, Quaternion.identity);
                spawned[spawnLoc] = true;
                spawnedCount++;
            }

        }
    }

  
}
