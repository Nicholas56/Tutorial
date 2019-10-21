using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject thingToSpawn;
    [SerializeField] GameObject megaSpawnObject;
    [SerializeField] float delayBetweenSpawns = 2.0f;
    [SerializeField] float timeOfNextSpawn = 1f;
    int amountToSpawn = 10;
    int spawnCount;
    static int amountSpawned = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeOfNextSpawn&&amountSpawned<amountToSpawn)
        {
            if (spawnCount >= 10)
            {
                Instantiate(megaSpawnObject, transform.position, Quaternion.identity);
                spawnCount = 0;
            }
            else
            {
                Instantiate(thingToSpawn, transform.position, Quaternion.identity);
            }
            timeOfNextSpawn = Time.time + delayBetweenSpawns;
            amountSpawned++;
            spawnCount++;
        }
    }

    static public void EnemyDie()
    {
        amountSpawned--;
    }
}
