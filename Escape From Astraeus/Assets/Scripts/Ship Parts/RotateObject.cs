using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool on;
    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            this.transform.Rotate(0,rotSpeed * Time.deltaTime,0 , Space.World);
        }
    }
}
