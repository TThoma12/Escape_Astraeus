using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSight : MonoBehaviour
{
    public float rayLength = 10.0f;
    public Vector3 rayAngle;
    public Vector3 rayAngle2;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rayAngle = rayAngle * Mathf.Deg2Rad;
        Debug.DrawRay(transform.position, transform.TransformDirection(rayAngle) * rayLength, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(rayAngle2) * rayLength, Color.red);
    }

    

    
}
