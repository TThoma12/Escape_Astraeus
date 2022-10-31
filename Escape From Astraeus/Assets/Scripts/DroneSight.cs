using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSight : MonoBehaviour
{
    // Code from https://www.youtube.com/watch?v=j1-OyLo77ss
    public float radius;
    [Range(0,360)]
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
     public GameObject playerController;
    private PlayerController playerControllerScript;
    public GameObject[] playerBots;
    private Vector3 distanceFromPlayer;
    
    
    void Start()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = playerController.GetComponent<PlayerController>();
        StartCoroutine(FOVRoutine());

        
    }

    // Update is called once per frame
    void Update()
    {
        //Switches player refrence depending on which bot is the player controlling
        // if (playerControllerScript.Bot1Active == true)
        //     {
        //        playerRef = playerBots[0];
        //     }
            
        //     if (playerControllerScript.Bot2Active == true)
        //     {
        //         playerRef = playerBots[1];
        //     }

        playerRef = playerControllerScript.bots[playerControllerScript.currentBot];
        
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length !=0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle /2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }

        else if(canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    

    
}
