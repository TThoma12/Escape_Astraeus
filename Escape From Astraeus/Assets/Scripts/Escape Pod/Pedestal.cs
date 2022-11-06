using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    public int pedestal_Num;
    public GameObject playerController;
    private PlayerInventory playerInventory;
    public GameObject escapePod;
    private EscapePod escapePodScript;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerController.GetComponent<PlayerInventory>();
        escapePodScript = escapePod.GetComponent<EscapePod>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
            if(playerInventory.Player_Ship_Parts[pedestal_Num] == true)
            {
                escapePodScript.have_Ship_part[pedestal_Num] = true;
            }
        }
    }
}
