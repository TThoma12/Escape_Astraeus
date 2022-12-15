using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string loadScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This code will start the game once the button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene(loadScreen);
        Debug.Log("Button Pressed");
    }

    //This code will close the game once the button is clicked
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Button Pressed / Closed Game");
    }
}
