using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    Vector3 moveDirection;
    public PlayerInput playerControls;
    private InputAction move;
    private InputAction flyUp;
    public InputAction BotSwitch;
    public InputAction Interact;
    public float playeRotspeed = 50.0f;
    public float playerSpeed = 5.0f;
    private PlayerSwitcher playerSwitcher;
    private DroneMove droneMoveScript;
    private DroneSight droneSightScript;
    public bool[] botsActivated;
    public GameObject[] bots;
    public int  currentBot, prevBot, activeBot, num_Spotted_Player, droneMode;
    public int playerLives =3, currentLives; 
    public bool turnOff, playerDied;
    public CinemachineVirtualCamera mainCam;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject deathChecker;
   

    private void Awake() 
    {
        playerControls = new PlayerInput();
        playerSwitcher = FindObjectOfType<PlayerSwitcher>();
        num_Spotted_Player = 0;
        currentLives = playerLives;
        deathChecker.SetActive(false);
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        flyUp = playerControls.Player.FlyUp;
        flyUp.Enable();

        BotSwitch = playerControls.Player.SwitchBot;
        BotSwitch.Enable();

        Interact = playerControls.Player.Interact;
        Interact.Enable();
    }

    private void OnDisable() 
    {   
        move.Disable();
        flyUp.Disable();
        BotSwitch.Disable();
        Interact.Disable();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        //botsActivated[0] = true;
        
    }
    void LateUpdate() 
    {
        //LowerLives();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player Movement
        moveDirection = move.ReadValue<Vector2>();

        float forward = moveDirection.y * playerSpeed;
        float rotate = moveDirection.x * playeRotspeed;

        forward *= Time.deltaTime;
        rotate *= Time.deltaTime;


        //Sets which of the bots the player is controlling
        for(currentBot = 0; currentBot < botsActivated.Length; currentBot++)
        {
             if (botsActivated[currentBot])
        {
            switch (currentBot)
            {
                case 0:
                    bots[0].transform.Translate(0,0,forward);
                    bots[0].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[0].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[0].transform;
                    mainCam.m_LookAt = bots[0].transform;
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 0;
                    prevBot = 0;

                break;

                case 1:
                    bots[1].transform.Translate(0,0,forward);
                    bots[1].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[1].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[1].transform;
                    mainCam.m_LookAt = bots[1].transform;
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 1;
                    prevBot = 1;
       
                break;
                 case 2:
                    bots[2].transform.Translate(0,0,forward);
                    bots[2].transform.Rotate(0,rotate,0);
                    mainCam.m_Follow = bots[2].transform;
                    mainCam.m_LookAt = bots[2].transform;
                    // droneMoveScript = bots[2].GetComponent<DroneMove>();
                    // //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                   // droneMoveScript.botID = 2;
                    prevBot = 2;
            

                break;
                 case 3:
                    bots[3].transform.Translate(0,0,forward);
                    bots[3].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[3].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[3].transform;
                    mainCam.m_LookAt = bots[3].transform;
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 3;
                    prevBot = 3;
       
                break;
                 case 4:
                    bots[4].transform.Translate(0,0,forward);
                    bots[4].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[4].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[4].transform;
                    mainCam.m_LookAt = bots[4].transform;
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 3;
                    prevBot = 4;
       
                break;
                default:
                    droneMoveScript = bots[prevBot].GetComponent<DroneMove>();
                    droneMoveScript.playerInControl = false;
                    Debug.Log("Default");
                break;
            
                
            }
           
        }

            
        }

        currentBot = 0;

        LowerLives();
        playerDeath2();
      
      

    }

    public void SetOtherBotsOff()
    {
        
        int i;

        for(i=0; i < botsActivated.Length; i++ )
        {
        
           
                botsActivated[i] = false;
            
           
        }

  
        
    }

    public void LowerLives()
    {
        //  if(bots[prevBot].transform.position == spawn.transform.position)
        //  {
        //    StartCoroutine(playerDeath());
        //      playerDied = true;
        //  }

        if(playerDied)
        {
            deathChecker.SetActive(true);
            // switch(currentLives)
            // {
            //     case 3:
            //     currentLives = 2;
            //     playerDied = false;
            //     break;
            //     case 2:
            //     currentLives = 1;
            //     playerDied = false;
            //     break;
            //     case 1:
            //     currentLives = 0;
            //     playerDied = false;
            //     break;
            //     default:
            //     currentLives = 0;
            //     playerDied = false;
            //     break;
                
            // }
           // playerDied = false;

           //StartCoroutine(playerDeath());
           //playerDeath2();
            // Debug.Log("Player Died");
            // currentLives--;
            // playerDied = false;
        }
           

    }

    IEnumerator playerDeath()
    {
        yield return new WaitForSeconds(.001f);
        //playerDied = true;
        Debug.Log("Player Died");
        playerDied = false;
        StopCoroutine(playerDeath());
        //playerDied = false;
    }

    void playerDeath2()
    {
        if(currentLives == 0)
        {
            Debug.Log("Game Over");
        }
        
    }

    void Update() 
    {
        
    //    if (turnOff)
    //    {
    //         StartCoroutine(TurnOffAllBots());
           
    //    }
        
    }

    public IEnumerator TurnOffAllBots()
    {
       yield return new WaitForSeconds(0.1f);
         SetOtherBotsOff();
         StopAllCoroutines();
    }

    

    
}
