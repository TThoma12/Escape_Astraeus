using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool[] Player_Ship_Parts;
    [SerializeField]private int k,i;
    [SerializeField]private GameObject ShipPartManager;
    [SerializeField]private ShipPartManager shipPartManagerScript;
    [SerializeField]private bool partChosen, playerHasItem;
    // Start is called before the first frame update
    void Start()
    {
        shipPartManagerScript = ShipPartManager.GetComponent<ShipPartManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChooseShipPart()
    {
        CheckPlayerInv();
        if (playerHasItem)
        {
             partChosen = false;
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
    }

    void CheckPlayerInv()
    {
        for (i=0; i<Player_Ship_Parts.Length; i++)
        {
            if(Player_Ship_Parts[i])
            {
                playerHasItem = true;
            }
        }
    }
}
