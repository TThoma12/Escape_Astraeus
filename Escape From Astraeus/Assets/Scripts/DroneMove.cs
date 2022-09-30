using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{
    public GameObject[] patrolPoints;
    int currentPP = 0;
   
    public float speed;
    public float rSpeed = 10.0f;
    private NavMeshAgent drone;
    public float visDistance;
    public int randomPP;
    public Vector3 visionBox;
    
   
    // Start is called before the first frame update
    void Start()
    {
        drone = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
         

          drone.destination = patrolPoints[currentPP].transform.position;

          if (Vector3.Distance(transform.position, patrolPoints[currentPP].transform.position) < 2)
          {
                drone.destination = patrolPoints[currentPP].transform.position;

               randomPP = Random.Range(0,patrolPoints.Length);
               currentPP = randomPP;
          }  

         
    }
    
   void OnDrawGizmos() 
   {
          // Gizmos.color = Color.red;

          // Gizmos.DrawRay(transform.position, transform.forward * visDistance);
          // Gizmos.DrawWireCube(transform.position + transform.forward * visDistance, visionBox);
   }
    void MoveToPoint()
    {
     
       if (Vector3.Distance(transform.position, patrolPoints[currentPP].transform.position) < 2)
       {
            
       }

      /* if (currentPP >= patrolPoints.Length)
       {
            currentPP = 0;
       } */
       
       Quaternion lookatPP = Quaternion.LookRotation(patrolPoints[currentPP].transform.position - transform.position);
       transform.rotation = Quaternion.Slerp(transform.rotation, lookatPP, rSpeed * Time.deltaTime);

       transform.Translate(0,0,speed * Time.deltaTime);
        
    }

   
}
