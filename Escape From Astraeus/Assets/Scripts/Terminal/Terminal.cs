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
    public GameObject playerController;
    private PlayerController playerControllerScript;
    private bool playerOnTerminal, terminalOn;
    public GameObject terminalTextOBJ;
    public TMPro.TextMeshProUGUI terminalText;
    
    void Start()    
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
        droneMove = drone.GetComponent<DroneMove>();
        droneSight = drone.GetComponent<DroneSight>();
       
       
        terminalUi.SetActive(false);
        terminalOn = true;
        terminalText.color = new Color(0.2705883f,1,4365277,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.Interact.triggered && terminalOn)
        {
            Debug.Log("E");
            if (playerOnTerminal)
            {
                ShutDownDrone();
            }
            
        }

        if (!terminalOn)
        {
            terminalText.text = "Access Denied";
            terminalText.color = new Color(1,0.2688679f,0.2688679f,1);

           
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
       StartCoroutine(DroneShutDown());
    }

    IEnumerator DroneShutDown()
    {
        terminalText.text = "Hacking Drone...";
        terminalText.color = new Color(0.2705883f,1,0.4365277f,1);
        yield return new WaitForSeconds(5f);
        
        droneMove.On = false;
        droneSight.enabled = false;

       
        StartCoroutine(TurnDroneOn());
        //StopAllCoroutines();
    }

    IEnumerator TurnDroneOn()
    {
        terminalText.text = "Drone Rebooting...";
        yield return new WaitForSeconds(8f);
        droneMove.On = true;
        droneSight.enabled = true;
        terminalOn = false;

        
         StopAllCoroutines();
    }
}
