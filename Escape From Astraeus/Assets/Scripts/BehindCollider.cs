using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindCollider : MonoBehaviour
{
    public bool playerIsBehind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerIsBehind = true;
            Debug.Log("Player Is Behind");
        }
        
    }

    void OnCollisionExit(Collision collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerIsBehind = false;
        }
    }

    
}
