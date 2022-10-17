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
    public bool[] botsActivated;
    public GameObject[] bots;
    private int x;

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
        //botsActivated[1] = true;
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

        // //Sets Robot 1 controls
        // if (Bot1Active)
        // {
        //     Bot1.transform.Translate(0,0,forward);
        //     Bot1.transform.Rotate(0,rotate,0);
        // }

        // //Sets Robots 2 controls
        // if (Bot2Active)
        // {
        //     Bot2.transform.Translate(0,0,forward);
        //     Bot2.transform.Rotate(0,rotate,0);
        // }
        for(x = 0; x < botsActivated.Length; x++)
        {
             if (botsActivated[x])
       {
            switch (x)
            {
                case 0:
                    bots[0].transform.Translate(0,0,forward);
                    bots[0].transform.Rotate(0,rotate,0);
                   // Debug.Log("0");
                break;

                case 1:
                    bots[1].transform.Translate(0,0,forward);
                    bots[1].transform.Rotate(0,rotate,0);
                    //Debug.Log("1");
                break;
                
            }
           
       }
        }

        x = 0;
      
        

    }

    void Update() 
    {
        // If tab is pressed switches between two robots.
        // if(BotSwitch.triggered)
        // {
        //     if(Bot1Active)
        //     {
        //         Bot2Active = true;
        //         Bot1Active = false;

        //         playerSwitcher.SwitchToBot2();
        //     }
        //     else
        //     {
        //         Bot2Active = false;
        //         Bot1Active = true;

        //         playerSwitcher.SwitchToBot1();
        //     }
  
        // }

        // if(Interact.triggered)
        // {
        //     Debug.Log("EE");
        // }
    }

    

    
}
