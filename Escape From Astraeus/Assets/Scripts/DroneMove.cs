using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{
    public GameObject[] patrolPoints;
    int currentPP = 0;
   
    public float speed;
    public float rSpeed = 10.0f;
    private NavMeshAgent drone;
    public float visDistance;
    public int randomPP, botID;
    public Vector3 visionBox;
    public bool On, playerInView;
    private DroneSight droneSight;
    public GameObject player;
    public GameObject[] playerBots;
    public GameObject playerSpawn;
    public GameObject playerController;
    public GameObject behindCollider;
    private PlayerController playerControllerScript;
    private BehindCollider behindColliderScript;
    public bool oneBot, playerInControl;
    public Camera droneCam;

    
   
    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<NavMeshAgent>();
        droneSight = GetComponent<DroneSight>();
        playerControllerScript = playerController.GetComponent<PlayerController>();
        behindColliderScript = behindCollider.GetComponent<BehindCollider>();
        playerInControl = false;
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if (On && !droneSight.canSeePlayer)
        {
           DronePatrol();
        }

        //If the robot can see the player
        if(droneSight.canSeePlayer)
        {
          
        }

        // Prevents the drone form moving when it's turned off
        if (!On)
        {
            drone.destination = this.transform.position;
        }

        //Checks if the player is currenty on controlling the robot
        if (playerControllerScript.prevBot == botID)
        {
            ShutdownDrone();
            droneCam.enabled = true;
            tag = "Player";
            gameObject.layer = 6;
        }
        else
        {
            turnOnDrone();
            droneCam.enabled = false;
            tag = "Drone";
             gameObject.layer = 0;
        }

        if(playerControllerScript.Interact.triggered && behindColliderScript.hackable == true)
        {
            bool botsOff = false;
            
            //StartCoroutine(playerControllerScript.TurnOffAllBots());
            playerControllerScript.SetOtherBotsOff();
            botsOff = true;

            if (botsOff)
            {
                playerControllerScript.botsActivated[botID] = true;
                botsOff = false;
            }
           
        }
          
       

    
    }

    void ShutdownDrone()
    {
        On = false;
        droneSight.enabled = false;
    }

    void turnOnDrone()
    {
        On = true;
        droneSight.enabled = true;
        playerInControl = false;
    }

    void DroneRushPlayer()
    {
            
    }

    void DronePatrol()
    {
         drone.destination = patrolPoints[currentPP].transform.position;

          if (Vector3.Distance(transform.position, patrolPoints[currentPP].transform.position) < 2)
          {
                drone.destination = patrolPoints[currentPP].transform.position;

               randomPP = Random.Range(0,patrolPoints.Length);
               currentPP = randomPP;
          }  
    }
    
   void OnDrawGizmos() 
   {
          // Gizmos.color = Color.red;

          // Gizmos.DrawRay(transform.position, transform.forward * visDistance);
          // Gizmos.DrawWireCube(transform.position + transform.forward * visDistance, visionBox);
   }
    void MoveToPoint()
    {
     
       if (Vector3.Distance(transform.position, patrolPoints[currentPP].transform.position) < 2)
       {
            
       }

      /* if (currentPP >= patrolPoints.Length)
       {
            currentPP = 0;
       } */
       
       Quaternion lookatPP = Quaternion.LookRotation(patrolPoints[currentPP].transform.position - transform.position);
       transform.rotation = Quaternion.Slerp(transform.rotation, lookatPP, rSpeed * Time.deltaTime);

       transform.Translate(0,0,speed * Time.deltaTime);
        
    }

   
}
