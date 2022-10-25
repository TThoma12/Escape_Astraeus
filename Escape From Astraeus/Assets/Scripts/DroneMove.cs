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
    private PlayerController playerControllerScript;
    public bool oneBot, playerInControl;

    
   
    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<NavMeshAgent>();
        droneSight = GetComponent<DroneSight>();
        playerControllerScript = playerController.GetComponent<PlayerController>();
        playerInControl = false;
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if (On && !droneSight.canSeePlayer)
        {
           DronePatrol();
        }

        if(droneSight.canSeePlayer)
        {
            // if (playerControllerScript.Bot1Active == true)
            // {
            //     drone.destination = playerBots[0].transform.position;
            //     playerBots[0].transform.position = playerSpawn.transform.position;
            // }
            
            // if (playerControllerScript.Bot2Active == true)
            // {
            //     drone.destination = playerBots[1].transform.position;
            //     playerBots[1].transform.position = playerSpawn.transform.position;
            // }
           
        }

        // Prevents the drone form moving when it's turned off
        if (!On)
        {
            drone.destination = this.transform.position;
        }

        if (playerControllerScript.prevBot == botID)
        {
            ShutdownDrone();
        }
        else
        {
            turnOnDrone();

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
