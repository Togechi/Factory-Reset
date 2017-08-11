using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    private float currentHealth;
    private float maxHealth;

    private float currentBombs;
    private float maxBombs;

    public static bool InStage;

    private Fire player;

    public bool continueToNextStage= true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InStage = true;
    }

    private void OnLevelWasLoaded(int level)
    {
        player = FindObjectOfType<Fire>();
    }

    private void Update()
    {
        if (InStage)
        {
            currentHealth = Fire.currentHealth;
            maxHealth = Fire.maxHealth;

            currentBombs = Fire.currentBombs;
            maxBombs = Fire.maxBombs;
        } else if (!InStage && player)
        {
            Fire.currentHealth = currentHealth;
            Fire.maxHealth = maxHealth;

            Fire.currentBombs = currentBombs;
            Fire.maxBombs = maxBombs;

            player.CountBombs();
            player.SetHealthBarValue();

            InStage = true;
        }
    }
}
