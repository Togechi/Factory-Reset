using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    GameObject[] pauseScreenObjects;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseScreenObjects = GameObject.FindGameObjectsWithTag("PauseScreen");
        GameUnpaused();
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GamePaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                GameUnpaused();
            }
        }

    }

    public void GamePaused ()
    {
        foreach (GameObject objects in pauseScreenObjects)
        {
            objects.SetActive(true);
        }
    }

    public void GameUnpaused()
    {
        foreach (GameObject objects in pauseScreenObjects)
        {
            objects.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
