using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject terminalUi;
    public GameObject drone;
    private DroneMove droneMove;
    private DroneSight droneSight;
    public GameObject playerController;
    private PlayerController playerControllerScript;
    [SerializeField]private bool playerOnTerminal, terminalOn;
    //public GameObject terminalTextOBJ;
    //public TMPro.TextMeshProUGUI terminalText;
    [SerializeField] private GameObject [] onAndOff;
    [SerializeField] private AudioSource terminalActivatedSFX;
    
    void Start()    
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
        droneMove = drone.GetComponent<DroneMove>();
        droneSight = drone.GetComponent<DroneSight>();
       
       
        //terminalUi.SetActive(false);
        terminalOn = true;
        //terminalText.color = new Color(0.2705883f,1,4365277,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.Interact.triggered && terminalOn)
        {
            //Debug.Log("E");
            if (playerOnTerminal)
            {
                terminalActivatedSFX.Play();
                ShutDownDrone();
            }
            
        }

        if (!terminalOn)
        {
            //terminalText.text = "Access Denied";
            //terminalText.color = new Color(1,0.2688679f,0.2688679f,1);

           
        }
    }

    void OnCollisionEnter(Collision collision) 
    {

       

    }

    private void OnTriggerEnter(Collider collider) 
    {
         if (collider.gameObject.tag == "Player")
        {
            //terminalUi.SetActive(true);
            Debug.Log("Close");
            playerOnTerminal = true;
            onAndOff[0].SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider) 
    {
         playerOnTerminal = false;
    }

    void OnCollisionExit(Collision collision) 
    {
        //terminalUi.SetActive(false);
       
    }

    void ShutDownDrone()
    {
       StartCoroutine(DroneShutDown());
    }

    IEnumerator DroneShutDown()
    {
        // terminalText.text = "Hacking Drone...";
        // terminalText.color = new Color(0.2705883f,1,0.4365277f,1);
        Debug.Log("Shutting down drone");
        onAndOff[1].SetActive(true);
        onAndOff[0].SetActive(false);
        yield return new WaitForSeconds(2f);
        
        //droneMove.On = false;
        droneMove.droneLight.SetActive(false);
        droneMove.enabled = false;
        //droneMove.ShutdownDrone();
        droneSight.enabled = false;

       
        StartCoroutine(TurnDroneOn());
        //StopAllCoroutines();
    }

    IEnumerator TurnDroneOn()
    {
        //terminalText.text = "Drone Rebooting...";
        yield return new WaitForSeconds(10f);
        //droneMove.On = true;
        //droneMove.turnOnDrone();
        droneMove.droneLight.SetActive(true);
        droneSight.enabled = true;
        droneMove.enabled = true;
        terminalOn = false;

        
         StopAllCoroutines();
    }
}
