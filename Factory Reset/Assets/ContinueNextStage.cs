using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueNextStage : MonoBehaviour {

    private PlayerData playerData;

    private bool continueStage;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}

    private void OnLevelWasLoaded(int level)
    {
        playerData = FindObjectOfType<PlayerData>();
        if (playerData)
        {
            playerData.continueToNextStage = continueStage;
        }
    }

    public void ContinueToNextStage (bool continueS)
    {
        if (continueS == true)
        {
            continueStage = true;
        } else if (!continueS)
        {
            continueStage = false;
        }
    }
}
