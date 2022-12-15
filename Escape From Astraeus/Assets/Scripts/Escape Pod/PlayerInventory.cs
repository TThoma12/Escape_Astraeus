using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool[] Player_Ship_Parts;
    [SerializeField]private int k,i,p;
    [SerializeField]private GameObject ShipPartManager;
    [SerializeField]private ShipPartManager shipPartManagerScript;
    [SerializeField]private bool partChosen = false, playerHasItem, test;
    [SerializeField] AudioSource pickSFX;
    // Start is called before the first frame update
    void Start()
    {
        shipPartManagerScript = ShipPartManager.GetComponent<ShipPartManager>();
    }

    // Update is called once per frame
    void Update()
    {
         CheckPlayerInv();
         //ChooseShipPart();
         if(playerHasItem)
         {
                if(test)
            {
                k = Random.Range(0,Player_Ship_Parts.Length);
                if(Player_Ship_Parts[k])
                {
                    test = false;
                    ChooseShipPart();
                }
                
            }
         }

       
        
    }

    public void ChooseShipPart()
    {
        Player_Ship_Parts[k] = false;
        shipPartManagerScript.SpawnSpecificPart(k);
        partChosen = true;
       
       
    }

    public void RandomShipPart()
    {
        
        //  if(!partChosen)
        //  {
        //      k = Random.Range(0,Player_Ship_Parts.Length);

        //     // if(!Player_Ship_Parts[k])
        //     // {
        //     //     //RandomShipPart();
        //     //       k = Random.Range(0,Player_Ship_Parts.Length);
        //     // }
        //     // else
        //     // {
        //     //     partChosen = true;
        //     //     k = p;
        //     // }

        //     if(Player_Ship_Parts[k])
        //     {
        //         partChosen = true;
        //         k = p;
        //     }
        //  }
        
    }

    public void TurnTestOne()
    {
        test = true;
    }

    void CheckPlayerInv()
    {
      
            if(Player_Ship_Parts[0] ||Player_Ship_Parts[1] ||Player_Ship_Parts[2] ||Player_Ship_Parts[3])
            {
                playerHasItem = true;
                //partChosen = false;
            }
            else
            {
                playerHasItem = false;
            }

    }
    void GeneratePart()
    {}

    public void playSFX()
    {
        pickSFX.Play();
    }

    
}
