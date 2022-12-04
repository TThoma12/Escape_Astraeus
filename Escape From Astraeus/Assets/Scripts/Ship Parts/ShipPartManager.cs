using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartManager : MonoBehaviour
{
    [SerializeField]private GameObject[] shiparts;
    [SerializeField]private GameObject[] partSpawnLocations;
    [SerializeField]private bool[] spawnLocationActive;
    [SerializeField]private int k,i;
     [SerializeField]private bool randomizedSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnShipParts();
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    void SpawnShipParts()
    {
         for (i = 0; i<shiparts.Length; i++)
       {
        RandomSpawnPos();
        Instantiate(shiparts[i], partSpawnLocations[k].transform.position, Quaternion.identity);
       }
    }
    void RandomSpawnPos()
    {
        
        k = Random.Range(0, partSpawnLocations.Length);
        if (spawnLocationActive[k])
        {
            RandomSpawnPos();
        }
        else
        {
            spawnLocationActive[k] = true;
        }
        
            
  
    }

    public void SpawnSpecificPart(int part)
    {
        RandomSpawnPos();
        Instantiate(shiparts[part], partSpawnLocations[k].transform.position, Quaternion.identity);
    }


}
