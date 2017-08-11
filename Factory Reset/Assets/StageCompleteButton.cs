using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCompleteButton : MonoBehaviour {

    private PlayerData playerData;

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        if (playerData)
        {
            EnableDisableButton();
        }

    }

    void EnableDisableButton ()
    {
        if (playerData.continueToNextStage)
        {
            gameObject.SetActive(true);
        } else if (!playerData.continueToNextStage)
        {
            gameObject.SetActive(false);
        }
    }
}
