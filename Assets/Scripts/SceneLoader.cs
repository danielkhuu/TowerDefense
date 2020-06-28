using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void Start()
    {
        Invoke("InstructionsScene", 4f);
    }
    public void InstructionsScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
