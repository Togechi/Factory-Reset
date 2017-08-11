﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager2 : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled");
        } else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }

    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}