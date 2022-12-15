using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangePlay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject button;
    [SerializeField] private string sceneName;
    void Start()
    {
        StartCoroutine(LoadingScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(19f);
        button.SetActive(true);
        StopCoroutine(LoadingScreen());

    }
}
