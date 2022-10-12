using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject terminalUi;
    public GameObject drone;
    private DroneMove droneMove;
    private DroneSight droneSight;
    private PlayerController playerController;
    private bool playerOnTerminal;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        droneMove = drone.GetComponent<DroneMove>();
        droneSight = drone.GetComponent<DroneSight>();
        terminalUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.Interact.triggered)
        {
            Debug.Log("E");
            if (playerOnTerminal)
            {
                ShutDownDrone();
            }
            
        }
    }

    void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.tag == "Player")
        {
            terminalUi.SetActive(true);
            Debug.Log("Close");
            playerOnTerminal = true;
        }

    }

    void OnCollisionExit(Collision collision) 
    {
        terminalUi.SetActive(false);
        playerOnTerminal = false;
    }

    void ShutDownDrone()
    {
        droneMove.On = false;
        droneSight.enabled = false;
    }
}
