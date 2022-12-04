using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class DroneMove : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public int currentPP = 0;
   
    public float speed;
    public float rSpeed = 10.0f;
    private NavMeshAgent drone;
    public int randomPP, botID, playerSpottedCounter;
    public bool On, playerInView, playerSpotted, droneRushingPlayer;
    private DroneSight droneSight;
    public GameObject player;
    public GameObject playerSpawn;
    public GameObject playerController;
    public GameObject behindCollider;
    [SerializeField]private GameObject droneLight;
    private PlayerController playerControllerScript;
    private PlayerInventory playerInventoryScript;
    private BehindCollider behindColliderScript;
    public bool oneBot, playerInControl, searchMode, playerAtSapwn;
    public Camera droneCam;
    public GameObject exclamationMark, questionMark;
    public int layerMaskNum;
    [SerializeField] private int num_Spotted_Player, spottedNum;
    private Vector3 player_Last_Seen_pos;
    [SerializeField] private Magnitization magnitizationScript;



    
   
    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<NavMeshAgent>();
        droneSight = GetComponent<DroneSight>();
        playerControllerScript = playerController.GetComponent<PlayerController>();
        playerInventoryScript = playerController.GetComponent<PlayerInventory>();
        behindColliderScript = behindCollider.GetComponent<BehindCollider>();
        playerInControl = false;
        spottedNum = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerInControl)
        {
            DroneStates();
        }
        
        

        if (On && !droneSight.canSeePlayer)
        {
            if(!droneRushingPlayer)
            {
                //DronePatrol();
                drone.isStopped = false;
                DroneFollowPath();
            }
           
           //DroneFollowPath();
        }

        //If the robot can see the player
        
        if(droneSight.canSeePlayer)     // Checks weather the drone can see the player usong the drone sight script.
        {
            //StartCoroutine(Set_Num_Spotted_Player());
            playerSpotted = true;
            drone.destination = this.transform.position;
            SpottedPlayer();
            player_Last_Seen_pos = droneSight.playerRef.transform.position;
        }
        else
        { 
            if(playerSpotted)
            {
                StartCoroutine(Set_Num_Spotted_Player(true)); // If the drone spots the player it starts the checks how many times it has seen the player. When the player is spotted
                                                            //The it turns the coroutine, when the player leaves it ticks the number times it has spotted the player plus 1. 
                
                playerSpotted = false;
            }
                
        }

        // Prevents the drone form moving when it's turned off
        if (!On)
        {
            drone.destination = this.transform.position;
            drone.isStopped = true;
            //StartCoroutine(turnDroneRushOff());
            
        }

        //Checks if the player is currenty on controlling the robot
        if (playerControllerScript.prevBot == botID)
        {
            ShutdownDrone();
            magnitizationScript.enabled = true;
            droneLight.SetActive(false);
            //droneCam.enabled = true;
            tag = "Player";
            gameObject.layer = 6;
            //droneSight.targetMask = 0;
        }
        else
        {
            // If the player is not in control set the tag  of the drone to "Drone"
            turnOnDrone();
            magnitizationScript.enabled = false;
            droneLight.SetActive(true);
            //droneCam.enabled = false;
            tag = "Drone";
             gameObject.layer = 0;
            
        }

        //Drone Hacking. Checks if the player is behind the the robot and when the player presses E the player becomes the drone.

        if(playerControllerScript.Interact.triggered && behindColliderScript.hackable == true)
        {
            Debug.Log("Hacking");
            StartCoroutine(Set_Num_Spotted_Player(false));
            bool botsOff = false;
            behindColliderScript.hackable = false;
            playerControllerScript.SetOtherBotsOff();
            playerControllerScript.num_Spotted_Player = 0;

            exclamationMark.SetActive(false);
        questionMark.SetActive(false);
        
            botsOff = true;

            if (botsOff)
            {
                playerControllerScript.botsActivated[botID] = true;
                botsOff = false;
            }

        }

        //PlayerDeath();    
    
    }

    void DroneStates()
    {
        switch(playerControllerScript.num_Spotted_Player)
        {
           case 0:
           defaultMode();
           break; 
           case 1:
           AlerMode();
            StartCoroutine(Set_Num_Spotted_Player(true));
           break;
           case 2:
           HuntMode();
           break;
           case 3:
           break;
           case 4:
           break;    
        }
    }

    void AlerMode()
    {
        drone.speed = 4f;
        questionMark.SetActive(true);
        
    }

    void HuntMode()
    {
       

        exclamationMark.SetActive(true);
        questionMark.SetActive(false);
        if (playerSpotted)
        {
            playerControllerScript.bots[playerControllerScript.prevBot].transform.position = playerSpawn.transform.position;

            playerControllerScript.playerDied = true;
            //playerControllerScript.playerDied = false;
            //Debug.Log("PlayerSpotted");
            
            //playerInventoryScript.ChooseShipPart();

            //playerControllerScript.playerDied = false;
        }
      

       


       
    }

    void defaultMode()
    {
        drone.speed = 3.5f;
        exclamationMark.SetActive(false);
        questionMark.SetActive(false);
    }

    

    IEnumerator Set_Num_Spotted_Player(bool increase)
    {
       if (playerControllerScript.num_Spotted_Player < 2 && increase)
       {
            //num_Spotted_Player++;
            playerControllerScript.num_Spotted_Player++;
            yield return new WaitForSeconds(.1f);
            StopCoroutine(Set_Num_Spotted_Player(increase));
       } 

       if (playerControllerScript.num_Spotted_Player == 2 && !increase)
       {
            playerControllerScript.num_Spotted_Player = 0;
            yield return new WaitForSeconds(.1f);
            StopCoroutine(Set_Num_Spotted_Player(increase));
       }
        
    }

    IEnumerator Increase_Spot_Num()
    {
        spottedNum++;
        yield return new WaitForSeconds(.1f);
        StopCoroutine(Increase_Spot_Num());
    }

    void SpottedPlayer()
    {
        StartCoroutine(DroneRushPlayer(player_Last_Seen_pos));
    }

    void ShutdownDrone()
    {
        On = false;
        droneSight.enabled = false;
    }

    void turnOnDrone()
    {
       StartCoroutine(turnDroneOn());
    }

    IEnumerator DroneRushPlayer(Vector3 playerPos)
    {
        droneRushingPlayer = true;
        Vector3 player_Last_Pos;
        player_Last_Pos = playerPos;
        yield return new WaitForSeconds(3f);
        drone.destination = player_Last_Pos;

      
        StopCoroutine(DroneRushPlayer(playerPos));
        StartCoroutine(turnDroneRushOff());
        
  
        
    }

    IEnumerator turnDroneRushOff()
    {
        yield return new WaitForSeconds(.1f);
        drone.destination = this.transform.position;
        droneRushingPlayer = false;
        StopCoroutine(turnDroneRushOff());
    }

    IEnumerator LookTowardsPlayer()
    {

        drone.destination = this.transform.position;
        transform.LookAt(droneSight.playerRef.transform.position);
        yield return new WaitForSeconds(3f);
        searchMode = true;
        StopCoroutine(LookTowardsPlayer());

    }

    IEnumerator turnDroneOn()
    {
        yield return new WaitForSeconds(4f);
        On = true;
        droneSight.enabled = true;
        playerInControl = false;
        StopCoroutine(turnDroneOn());
    }

    void DroneMode(string Mode)
    {
        switch(Mode)
        {
            case "Alert":
            StartCoroutine(LookTowardsPlayer());
            


            break;
            case "Searching":

              if (droneSight.canSeePlayer)
            {
                droneSight.playerRef.transform.position = playerSpawn.transform.position;
                
            }
            break;
        }

        
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

    void PlayerDeath()
    {
         if(playerAtSapwn)
        {
           
            playerControllerScript.playerDied = true;
             playerAtSapwn = false;
        }
    }

    void DroneFollowPath()
    {
        //currentPP = 0;
        drone.destination = patrolPoints[currentPP].transform.position;
        
        if(currentPP < patrolPoints.Length)
        {

            if (Vector3.Distance(transform.position, patrolPoints[currentPP].transform.position) < 2)
            {
                 
                if (currentPP < patrolPoints.Length -1)
                {
                   
                    drone.destination = patrolPoints[currentPP].transform.position;
                    currentPP++;
                    //DroneFollowPath();
                }
                else
                {
                    currentPP = 0;
                    drone.destination = patrolPoints[currentPP].transform.position;
                }
                   
                
                
                
            } 

        }
       
    }

    IEnumerator NoticePlayer()
    {
        //StopCoroutine(LookTowardsPlayer());
        this.transform.LookAt(droneSight.playerRef.transform.position);
        yield return new WaitForSeconds(3f);
        StopCoroutine(NoticePlayer());  
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
