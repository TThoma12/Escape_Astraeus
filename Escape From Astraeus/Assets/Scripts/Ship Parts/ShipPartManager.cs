using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartManager : MonoBehaviour
{
    [SerializeField]private GameObject[] shiparts;
    [SerializeField]private GameObject[] partSpawnLocations;
    [SerializeField]private bool[] spawnLocationActive;
    [SerializeField]private int k,i,p;
     [SerializeField]private bool randomizedSpawn ,locationFound;

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
        Instantiate(shiparts[i], partSpawnLocations[p].transform.position, Quaternion.identity);
        locationFound = true;
       }
    }
    void RandomSpawnPos()
    {
        if (locationFound)
        {
             k = Random.Range(0, partSpawnLocations.Length);
            if (!spawnLocationActive[k])
            {
                 spawnLocationActive[k] = true;
                 locationFound = false;
                 p = k;
            }
           
          
        }
       
        
            
  
    }

    public void SpawnSpecificPart(int part)
    {
        RandomSpawnPos();
        Instantiate(shiparts[part], partSpawnLocations[p].transform.position, Quaternion.identity);
    }


}
