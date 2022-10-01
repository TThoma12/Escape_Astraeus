using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSight : MonoBehaviour
{
    public float rayLength = 10.0f;
    public float rayAngle;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rayAngle = rayAngle * Mathf.Deg2Rad;
        Debug.DrawRay(transform.position, transform.TransformDirection(0, 0, rayAngle) * rayLength, Color.red);
    }

    

    
}
