using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheckr : MonoBehaviour
{
    public GameObject playerController;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
            if(playerControllerScript.currentLives < 0)
            {
                playerControllerScript.currentLives--;
            }
            
        }
    }
}
