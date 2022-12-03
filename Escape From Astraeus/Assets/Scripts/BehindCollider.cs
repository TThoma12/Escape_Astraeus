using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehindCollider : MonoBehaviour
{
    public bool playerIsBehind, hackable;
    //public GameObject takeOverText;
    private PlayerController playerControllerScript;
    public GameObject playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
        //takeOverText.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
         if(playerIsBehind == true && hackable == true)
        {
             //takeOverText.SetActive(true);
        }
         if(!hackable)
        {
            //takeOverText.SetActive(false);
        }
    }
     void OnTriggerEnter(Collider collider) 
    {
         if (collider.gameObject.tag == "Player")
        {
            playerIsBehind = true;
            Debug.Log("Player Is Behind");
            StartCoroutine(DroneTakeOver());
        }

       
    }

     void OnTriggerExit(Collider collider) 
    {
         if (collider.gameObject.tag == "Player")
        {
            playerIsBehind = false;
            //takeOverText.SetActive(false);
            hackable = false;
            StopAllCoroutines();
        }
    }

    IEnumerator DroneTakeOver()
    {
        yield return new WaitForSeconds(1.3f);
        hackable = true;
       
    }

    
}
