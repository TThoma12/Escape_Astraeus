using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject terminalUi;
    void Start()
    {
        terminalUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.tag == "Player")
        {
            terminalUi.SetActive(true);
            Debug.Log("Close");
        }

    }

    void OnCollisionExit(Collision collision) 
    {
        terminalUi.SetActive(false);
    }
}
