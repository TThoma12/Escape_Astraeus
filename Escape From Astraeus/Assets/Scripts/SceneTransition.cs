using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This code will activate the transition after the space bar is pressed
        if (Input.GetMouseButtonDown(0))
        {
            FadeToScreen(3);
        }
    }

    // This code will trigger the transition animation
    public void FadeToScreen(int levelIndex)
    {
        animator.SetTrigger("Fade Out");
    }
}
