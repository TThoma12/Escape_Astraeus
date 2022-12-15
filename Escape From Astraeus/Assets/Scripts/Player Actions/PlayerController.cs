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
    [SerializeField] private AudioSource AlarmStateSFX;
    [SerializeField] private AudioSource DroneMovingSFX;
    public bool Moving;
    [SerializeField] private Rigidbody currentBotRb;
    [SerializeField] private  Vector3 oldPos, newPos, velocity;

    
   

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
        move.performed += MoveTriggered;

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
        move.canceled += MoveTriggeredDisabled;

        flyUp.Disable();
        BotSwitch.Disable();
        Interact.Disable();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        //botsActivated[0] = true;
        oldPos = bots[prevBot].transform.position;
        
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
                    droneMoveScript.playerInControl = true;
                    prevBot = 0;

                break;

                case 1:
                    bots[1].transform.Translate(0,0,forward);
                    bots[1].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[1].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[1].transform;
                    mainCam.m_LookAt = bots[1].transform;
                    droneMoveScript.playerInControl = true;
                    prevBot = 1;
       
                break;
                 case 2:
                    bots[2].transform.Translate(0,0,forward);
                    bots[2].transform.Rotate(0,rotate,0);
                    mainCam.m_Follow = bots[2].transform;
                    mainCam.m_LookAt = bots[2].transform;
                    droneMoveScript.playerInControl = true;
                    prevBot = 2;
            

                break;
                 case 3:
                    bots[3].transform.Translate(0,0,forward);
                    bots[3].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[3].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[3].transform;
                    mainCam.m_LookAt = bots[3].transform;
                    droneMoveScript.playerInControl = true;
                    prevBot = 3;
       
                break;
                 case 4:
                    bots[4].transform.Translate(0,0,forward);
                    bots[4].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[4].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[4].transform;
                    mainCam.m_LookAt = bots[4].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 4;
       
                break;
                 case 5:
                    bots[5].transform.Translate(0,0,forward);
                    bots[5].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[5].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[5].transform;
                    mainCam.m_LookAt = bots[5].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 5;
       
                break;
                 case 6:
                    bots[6].transform.Translate(0,0,forward);
                    bots[6].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[6].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[6].transform;
                    mainCam.m_LookAt = bots[6].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 6;
       
                break;
                 case 7:
                    bots[7].transform.Translate(0,0,forward);
                    bots[7].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[7].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[7].transform;
                    mainCam.m_LookAt = bots[7].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 7;
       
                break;
                 case 8:
                    bots[8].transform.Translate(0,0,forward);
                    bots[8].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[8].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[8].transform;
                    mainCam.m_LookAt = bots[8].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 8;
       
                break;
                 case 9:
                    bots[9].transform.Translate(0,0,forward);
                    bots[9].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[9].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[9].transform;
                    mainCam.m_LookAt = bots[9].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 9;
       
                break;
                 case 10:
                    bots[10].transform.Translate(0,0,forward);
                    bots[10].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[10].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[10].transform;
                    mainCam.m_LookAt = bots[10].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 10;
       
                break;
                 case 11:
                    bots[11].transform.Translate(0,0,forward);
                    bots[11].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[11].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[11].transform;
                    mainCam.m_LookAt = bots[11].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 11;
       
                break;
                 case 12:
                    bots[12].transform.Translate(0,0,forward);
                    bots[12].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[12].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[12].transform;
                    mainCam.m_LookAt = bots[12].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 12;
       
                break;
                 case 13:
                    bots[13].transform.Translate(0,0,forward);
                    bots[13].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[13].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[13].transform;
                    mainCam.m_LookAt = bots[13].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 13;
       
                break;
                 case 14:
                    bots[14].transform.Translate(0,0,forward);
                    bots[14].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[14].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[14].transform;
                    mainCam.m_LookAt = bots[14].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 14;
       
                break;
                 case 15:
                    bots[15].transform.Translate(0,0,forward);
                    bots[15].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[15].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[15].transform;
                    mainCam.m_LookAt = bots[15].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 15;
       
                break;
                 case 16:
                    bots[16].transform.Translate(0,0,forward);
                    bots[16].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[16].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[16].transform;
                    mainCam.m_LookAt = bots[16].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 16;
       
                break;
                 case 17:
                    bots[17].transform.Translate(0,0,forward);
                    bots[17].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[17].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[17].transform;
                    mainCam.m_LookAt = bots[17].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 17;
       
                break;
                 case 18:
                    bots[18].transform.Translate(0,0,forward);
                    bots[18].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[18].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[18].transform;
                    mainCam.m_LookAt = bots[18].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 18;
       
                break;
                 case 19:
                    bots[19].transform.Translate(0,0,forward);
                    bots[19].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[19].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[19].transform;
                    mainCam.m_LookAt = bots[19].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 19;
       
                break;
                 case 20:
                    bots[20].transform.Translate(0,0,forward);
                    bots[20].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[20].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[20].transform;
                    mainCam.m_LookAt = bots[20].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 20;
       
                break;
                 case 21:
                    bots[21].transform.Translate(0,0,forward);
                    bots[21].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[21].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[21].transform;
                    mainCam.m_LookAt = bots[21].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 21;
       
                break;
                 case 22:
                    bots[22].transform.Translate(0,0,forward);
                    bots[22].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[22].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[22].transform;
                    mainCam.m_LookAt = bots[22].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 22;
       
                break;
                 case 23:
                    bots[23].transform.Translate(0,0,forward);
                    bots[23].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[23].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[23].transform;
                    mainCam.m_LookAt = bots[23].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 23;
       
                break;
                 case 24:
                    bots[24].transform.Translate(0,0,forward);
                    bots[24].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[24].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[24].transform;
                    mainCam.m_LookAt = bots[24].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 24;
       
                break;
                 case 25:
                    bots[25].transform.Translate(0,0,forward);
                    bots[25].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[25].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[25].transform;
                    mainCam.m_LookAt = bots[25].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 25;
       
                break;
                 case 26:
                    bots[26].transform.Translate(0,0,forward);
                    bots[26].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[26].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[26].transform;
                    mainCam.m_LookAt = bots[26].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 26;
       
                break;
                 case 27:
                    bots[27].transform.Translate(0,0,forward);
                    bots[27].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[27].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[27].transform;
                    mainCam.m_LookAt = bots[27].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 27;
       
                break;
                 case 28:
                    bots[28].transform.Translate(0,0,forward);
                    bots[28].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[28].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[28].transform;
                    mainCam.m_LookAt = bots[28].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 28;
       
                break;
                 case 29:
                    bots[29].transform.Translate(0,0,forward);
                    bots[29].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[29].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[29].transform;
                    mainCam.m_LookAt = bots[29].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 29;
       
                break;
                 case 30:
                    bots[30].transform.Translate(0,0,forward);
                    bots[30].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[30].GetComponent<DroneMove>();
                    mainCam.m_Follow = bots[30].transform;
                    mainCam.m_LookAt = bots[30].transform;           
                    droneMoveScript.playerInControl = true; 
                    prevBot = 30;
       
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
          if (num_Spotted_Player == 2)
            {
                //Debug.Log("Playing SFX");
                //AlarmStateSFX.Play();
            }
      
      

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
     

        if(playerDied)
        {
            deathChecker.SetActive(true);
           
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
        if(currentLives == 1)
        {
            //Debug.Log("PLAUY");
            //AlarmStateSFX.Play();
        }
        if(currentLives == 0)
        {
            Debug.Log("Game Over");
            AlarmStateSFX.Play();
        }
        
    }

    void Update() 
    {
         currentBotRb = bots[prevBot].GetComponent<Rigidbody>();
       

        newPos = bots[prevBot].transform.position;
        var media =  (newPos - oldPos);
        velocity = media /Time.deltaTime;
        oldPos = newPos;
        newPos = bots[prevBot].transform.position;

        //Debug.Log(velocity);
        if(velocity.x == 0)
        {
            Moving = false;
           // StartCoroutine(DroneMovingSFXStop());
        }

        if (velocity.x != 0)
        {
            Moving = true;
        }

        if(Moving)
        {
            if(!DroneMovingSFX.isPlaying)
            {
                //Moving = true;
                DroneMovingSFX.Play();
            }
        }
        else
        {
            //DroneMovingSFX.Stop();
            StartCoroutine(DroneMovingSFXStop());
        }
       
        
    }

    void MoveTriggered(InputAction.CallbackContext move)
    {
        if(move.performed)
        {
            
            if(!DroneMovingSFX.isPlaying)
            {
                //Moving = true;
                //DroneMovingSFX.Play();
            }
             
             //DroneMovingSFX.Stop();
        }
        else
        {   
            Moving = false;
            DroneMovingSFX.Stop();
        }
    }

    void MoveTriggeredDisabled(InputAction.CallbackContext move)
    {
        if(move.canceled)
        {
            Debug.Log("Stop");
            StartCoroutine(DroneMovingSFXStop());
        }
    }

    private IEnumerator DroneMovingSFXStop()
    {
        yield return new WaitForSeconds(1.5f);
        DroneMovingSFX.Stop();
        StopCoroutine(DroneMovingSFXStop());
    }

    public IEnumerator TurnOffAllBots()
    {
       yield return new WaitForSeconds(0.1f);
         SetOtherBotsOff();
         StopAllCoroutines();
    }

    

    
}
