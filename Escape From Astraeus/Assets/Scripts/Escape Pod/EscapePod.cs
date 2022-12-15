using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    // Start is called before the first frame update
     public bool[] have_Ship_part;
     private bool  hasAllParts;
     [SerializeField] private int totalShipParts;
     [SerializeField] private AudioSource GameWinSFX;
    
    void Start()
    {
        AllPartsFalse();
    }

    // Update is called once per frame
    void Update()
    {
        //HasAllParts();
        if(have_Ship_part[0] && have_Ship_part[1] && have_Ship_part[2] && have_Ship_part[3])
        {
             Debug.Log("Player Escaped!");
             GameWinSFX.Play();
        }
       
    }

    void AllPartsFalse()
    {
        int i;
        for (i = 0; i <have_Ship_part.Length;i++)
        {
            have_Ship_part[i] = false;
        }
    }

    void HasAllParts()
    {
        int k;
        for (k = 0; k <have_Ship_part.Length;k++)
        {
           if (!have_Ship_part[k])
           {
                hasAllParts = false;
           }
        }
    }
}
