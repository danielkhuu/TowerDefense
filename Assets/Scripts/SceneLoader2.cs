using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is called during win screen and lose screen
public class SceneLoader2 : MonoBehaviour
{
    void Start(){
        print("Hello from sceneloader2");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
