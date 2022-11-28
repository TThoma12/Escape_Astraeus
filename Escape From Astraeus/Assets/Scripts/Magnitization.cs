using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Magnitization : MonoBehaviour
{
    public GameObject rayStartPoint;
    public GameObject rayEndPoint;
    int layermask = 1 << 7; 
    public int hitDistance;
    public GameObject playerController;
    private PlayerController playerControllerScript;
    public bool crateInView, holdingCrate;
    public int moveDistance;
    

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
            if(hit.collider.gameObject.tag == "Crate")
            {
                 crateInView = true;
            }
           
            //Debug.Log("Hit Crate");
        }
        else
        {
            //Debug.Log("Hit Crate");
            crateInView = false;
        }
       
        



        if(playerControllerScript.Interact.triggered && crateInView == true)
        {
            //holdingCrate = true;
            hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y , hit.transform.position.z + moveDistance * Time.deltaTime);
            
        }

        if(playerControllerScript.BotSwitch.triggered && crateInView == true)
        {
            hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y , hit.transform.position.z - moveDistance * Time.deltaTime);
        }
}
    }

