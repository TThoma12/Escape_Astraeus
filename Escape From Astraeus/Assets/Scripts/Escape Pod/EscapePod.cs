using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    // Start is called before the first frame update
     public bool[] have_Ship_part;
    
    void Start()
    {
        AllPartsFalse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AllPartsFalse()
    {
        int i;
        for (i = 0; i <have_Ship_part.Length;i++)
        {
            have_Ship_part[i] = false;
        }
    }
}
