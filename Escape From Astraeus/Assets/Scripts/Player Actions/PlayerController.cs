using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 moveDirection;
    public PlayerInput playerControls;
    private InputAction move;
    private InputAction flyUp;
    private InputAction BotSwitch;
    public InputAction Interact;
    public float playeRotspeed = 50.0f;
    public float playerSpeed = 5.0f;
    private PlayerSwitcher playerSwitcher;
    private DroneMove droneMoveScript;
    private DroneSight droneSightScript;
    public bool[] botsActivated;
    public GameObject[] bots;
    public int  currentBot, prevBot, activeBot;
    public bool turnOff;
   

    private void Awake() 
    {
        playerControls = new PlayerInput();
        playerSwitcher = FindObjectOfType<PlayerSwitcher>();
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

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player Movement
        moveDirection = move.ReadValue<Vector2>();

        float forward = moveDirection.y * playerSpeed;
        float rotate = moveDirection.x * playeRotspeed;

        forward *= Time.deltaTime;
        rotate *= Time.deltaTime;


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
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 0;
                    prevBot = 0;

                break;

                case 1:
                    bots[1].transform.Translate(0,0,forward);
                    bots[1].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[1].GetComponent<DroneMove>();
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 1;
                    prevBot = 1;
       
                break;
                 case 2:
                    bots[2].transform.Translate(0,0,forward);
                    bots[2].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[2].GetComponent<DroneMove>();
                    //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                   // droneMoveScript.botID = 2;
                    prevBot = 2;
            

                break;
                 case 3:
                    bots[3].transform.Translate(0,0,forward);
                    bots[3].transform.Rotate(0,rotate,0);
                    droneMoveScript = bots[3].GetComponent<DroneMove>();
                     //SetOtherBotsOff();
                    droneMoveScript.playerInControl = true;
                    //droneMoveScript.botID = 3;
                    prevBot = 3;
       
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
      
        

    }

    public void SetOtherBotsOff()
    {
        
        int i;

        for(i=0; i < botsActivated.Length; i++ )
        {
        
           
                botsActivated[i] = false;
            
           
        }

        

      
        // switch(botNum)
        // {
        //     case 0:
        //     botsActivated[0] = true;
        //     botsActivated[1] = false;
        //     botsActivated[2] = false;
        //     botsActivated[3] = false;
        //     botsActivated[4] = false;
        //     botsActivated[5] = false;
        //     botsActivated[6] = false;
        //     break;
        //     case 1:
        //     botsActivated[0] = false;
        //     botsActivated[1] = true;
        //     botsActivated[2] = false;
        //     botsActivated[3] = false;
        //     botsActivated[4] = false;
        //     botsActivated[5] = false;
        //     botsActivated[6] = false;
        //     break;
        //     case 2:
        //     botsActivated[0] = false;
        //     botsActivated[1] = false;
        //     botsActivated[2] = true;
        //     botsActivated[3] = false;
        //     botsActivated[4] = false;
        //     botsActivated[5] = false;
        //     botsActivated[6] = false;
        //     break;
        //     case 3:
        //     botsActivated[0] = false;
        //     botsActivated[1] = false;
        //     botsActivated[2] = false;
        //     botsActivated[3] = true;
        //     botsActivated[4] = false;
        //     botsActivated[5] = false;
        //     botsActivated[6] = false;
        //     break;
        //     case 4:
        //     botsActivated[0] = false;
        //     botsActivated[1] = false;
        //     botsActivated[2] = false;
        //     botsActivated[3] = false;
        //     botsActivated[4] = true;
        //     botsActivated[5] = false;
        //     botsActivated[6] = false;
        //     break;
        //     case 5:
        //     botsActivated[0] = false;
        //     botsActivated[1] = false;
        //     botsActivated[2] = false;
        //     botsActivated[3] = false;
        //     botsActivated[4] = false;
        //     botsActivated[5] = true;
        //     botsActivated[6] = false;
        //     break;
        //     case 6:
        //     botsActivated[0] = false;
        //     botsActivated[1] = false;
        //     botsActivated[2] = false;
        //     botsActivated[3] = false;
        //     botsActivated[4] = false;
        //     botsActivated[5] = false;
        //     botsActivated[6] = true;
        //     break;
        // }
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
