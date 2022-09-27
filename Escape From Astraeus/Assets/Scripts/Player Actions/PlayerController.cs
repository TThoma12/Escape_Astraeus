using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 moveDirection;
    public PlayerInput playerControls;
    private InputAction move;
    public Rigidbody playerRb;
    public float playeRotspeed = 50.0f;
    public float playerSpeed = 5.0f;

    private void Awake() 
    {
        playerControls = new PlayerInput();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable() 
    {   
        move.Disable();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        moveDirection = move.ReadValue<Vector2>();

        float forward = moveDirection.y * playerSpeed;
        float rotate = moveDirection.x * playeRotspeed;

        forward *= Time.deltaTime;
        rotate *= Time.deltaTime;

        transform.Translate(0,0,forward);
        transform.Rotate(0,rotate,0);
    }
}
