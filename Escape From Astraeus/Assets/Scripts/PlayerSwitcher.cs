using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitcher : MonoBehaviour
{
    public Camera Bot1Cam;

    public Camera Bot2Cam;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToBot1()
    {
        Bot1Cam.enabled = true;
        Bot2Cam.enabled = false;
    }

    public void SwitchToBot2()
    {
        Bot1Cam.enabled = false;
        Bot2Cam.enabled = true;
    }

    
}
