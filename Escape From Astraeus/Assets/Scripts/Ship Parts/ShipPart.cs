using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    // Start is called before the first frame update
    private int rotSpeed = 60;
    public int shipPart_ID;
    public GameObject playerController;
    private PlayerInventory playerInventory;
    [SerializeField] AudioSource LocaIndicatorSFX;
    

    void Start()
    {
        playerController = GameObject.Find("PlayerController");
        playerInventory = playerController.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,rotSpeed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
             //pickSFX.Play();
            Update_Player_Inv(shipPart_ID);
           
            Destroy(gameObject);
        }
    }

    void Update_Player_Inv(int shipPart)
    {
              playerInventory.Player_Ship_Parts[shipPart] = true;
              playerInventory.playSFX();
    }
    
}
