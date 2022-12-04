using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool[] Player_Ship_Parts;
    [SerializeField]private int k,i;
    [SerializeField]private GameObject ShipPartManager;
    [SerializeField]private ShipPartManager shipPartManagerScript;
    [SerializeField]private bool partChosen = false, playerHasItem;
    // Start is called before the first frame update
    void Start()
    {
        shipPartManagerScript = ShipPartManager.GetComponent<ShipPartManager>();
    }

    // Update is called once per frame
    void Update()
    {
         CheckPlayerInv();
    }

    public void ChooseShipPart()
    {
      

        if (playerHasItem)
        {
                //partChosen = false;
                RandomShipPart();
            if(Player_Ship_Parts[k] && !partChosen)
            {
                Player_Ship_Parts[k] = false;
                shipPartManagerScript.SpawnSpecificPart(k);
                partChosen = true;
            }
        }
       
    }

    void RandomShipPart()
    {
         k = Random.Range(0,Player_Ship_Parts.Length);
         if(!Player_Ship_Parts[k])
         {
            RandomShipPart();
         }
    }

    void CheckPlayerInv()
    {
      
            if(Player_Ship_Parts[0] ||Player_Ship_Parts[1] ||Player_Ship_Parts[2] ||Player_Ship_Parts[3])
            {
                playerHasItem = true;
                partChosen = false;
            }
            else
            {
                playerHasItem = false;
            }

    }

    
}
