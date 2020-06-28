﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
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