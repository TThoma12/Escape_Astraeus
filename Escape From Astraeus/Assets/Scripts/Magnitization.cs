using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnitization : MonoBehaviour
{
    public GameObject rayStartPoint;
    public GameObject rayEndPoint;
    int layermask = 1 << 9; 
    public int hitDistance;
    public GameObject playerController;
    private PlayerController playerControllerScript;
    public bool crateInView, holdingCrate;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(rayStartPoint.transform.position, transform.TransformDirection(Vector3.forward), out hit,  Mathf.Infinity, layermask))
        {
            Debug.DrawRay(rayStartPoint.transform.position, transform.TransformDirection(Vector3.forward) * hitDistance, Color.blue);
            crateInView = true;
            //Debug.Log("Hit Crate");
        }
        else
        {
            crateInView = false;
        }



        if(playerControllerScript.Interact.triggered && crateInView == true)
        {
            holdingCrate = true;
            if (holdingCrate)
            {
                holdingCrate = false;
            }
            
        }

        if (holdingCrate)
            {
                hit.transform.position = rayEndPoint.transform.position;
            }
    }
}
