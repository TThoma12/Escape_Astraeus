using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTimedSpawn : MonoBehaviour
{

    public GameObject spawnee;
    public bool stopSpawing = false;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawing)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
