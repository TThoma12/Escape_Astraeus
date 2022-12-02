using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class Magnitization : MonoBehaviour
{
    public GameObject rayStartPoint;
    public GameObject rayEndPoint;
    int layermask = 1 << 7; 
    public int hitDistance;
    public GameObject playerController;
    private PlayerController playerControllerScript;
    [SerializeField]private bool crateInView, holdingCrate;
    [SerializeField]private int moveDistanceZ, moveDistanceX;
    public NavMeshSurface navMesh;
    [SerializeField]private bool reloading, on;
     [SerializeField]private string moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        on = true;
        playerControllerScript = playerController.GetComponent<PlayerController>();
        //navMesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            RaycastHit hit;

            if(Physics.Raycast(rayStartPoint.transform.position, transform.TransformDirection(Vector3.forward), out hit,  Mathf.Infinity, layermask))
            {
                Debug.DrawRay(rayStartPoint.transform.position, transform.TransformDirection(Vector3.forward) * hitDistance, Color.blue);
                if(hit.collider.gameObject.tag == "CrateZ")
                {
                    crateInView = true;
                    moveDirection = "Z";
                }

                 if(hit.collider.gameObject.tag == "CrateX")
                {
                    crateInView = true;
                    moveDirection = "X";
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
                switch (moveDirection)
                {
                    case "Z":
                        StartCoroutine(ReloadMagni());
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y , hit.transform.position.z + moveDistanceZ * Time.deltaTime);
                    break;
                    case "X":
                        StartCoroutine(ReloadMagni());
                        hit.transform.position = new Vector3(hit.transform.position.x + moveDistanceX * Time.deltaTime, hit.transform.position.y , hit.transform.position.z);
                    break;
                }
                
                //navMesh.BuildNavMesh();
                
            }

            if(playerControllerScript.BotSwitch.triggered && crateInView == true)
            {
                  switch (moveDirection)
                {
                    case "Z":
                        StartCoroutine(ReloadMagni());
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y , hit.transform.position.z + moveDistanceZ * Time.deltaTime);
                    break;
                    case "X":
                        StartCoroutine(ReloadMagni());
                        hit.transform.position = new Vector3(hit.transform.position.x + moveDistanceX * Time.deltaTime, hit.transform.position.y , hit.transform.position.z);
                    break;
                }
            }
        }
       
    }

    IEnumerator ReloadMagni()
    {
        on = false;
        crateInView = false;
        yield return new WaitForSeconds(1f);
        on = true;
        StopCoroutine(ReloadMagni());
    }
}

