using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyBonus : MonoBehaviour {

    private float difficulty;
    private float healthTimer;
    private float bombTimer;
    private float healthBonusTime = 0.09f;
    private float bombBonusTime = 5;

    public float healthDiff2 = 75;
    public int bombDiff2 = 1;

    private Fire fireScript;

    private void Start()
    {
        difficulty = PlayerPrefsManager.GetDifficulty();
        fireScript = FindObjectOfType<Fire>();
    }

    private void Update()
    {
        healthTimer += Time.deltaTime;
        bombTimer += Time.deltaTime;
        Diff1Bonus();
    }

    public void Diff1Bonus()
    {
        if (difficulty == 1)
        {
            Fire.maxBombs = 15;

            if (Fire.currentBombs < Fire.maxBombs)
            {
                if (bombTimer >= bombBonusTime)
                {
                    bombTimer = 0;
                    Fire.currentBombs++;
                    Mathf.Clamp(Fire.currentBombs, 0, Fire.maxBombs);
                    fireScript.CountBombs();
                    Debug.Log("Done");
                }
            }

            if (Fire.currentHealth < Fire.maxHealth)
            {
                if (healthTimer >= healthBonusTime)
                {
                    healthTimer = 0;
                    // Change it to a percentage of health instead of float
                    Fire.currentHealth += (0.1f * Fire.maxHealth);
                    Mathf.Clamp(Fire.currentHealth, 0, Fire.maxHealth);
                    fireScript.SetHealthBarValue();
                }
            }
        }
    }

    public void OnEnemyKilled()
    {
        if (difficulty == 2)
        {
            Fire.maxBombs = 10;

            if (Fire.currentBombs< Fire.maxBombs)
            {
                Fire.currentBombs++;
                fireScript.CountBombs();
            }


            if (Fire.currentHealth < Fire.maxHealth)
            {
                Fire.currentHealth += (0.08f * Fire.maxHealth);
                Mathf.Clamp(Fire.currentHealth, 0, Fire.maxHealth);
                fireScript.SetHealthBarValue();
            }
        }
        else if (difficulty == 6)
        {
            Fire.currentHealth -= 43f;
            fireScript.SetHealthBarValue();

            if (Fire.currentHealth <= 0)
            {
                Destroy(fireScript.gameObject);
                LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                level.LoadLevel("Lose");
            }
        }
    }

    public void OnWaveKilled()
    {
        if (difficulty == 3)
        {
            Fire.maxBombs = 5;

            if (Fire.currentBombs < Fire.maxBombs)
            {
                Fire.currentBombs++;
                fireScript.CountBombs();
            }

            if (Fire.currentHealth < Fire.maxHealth)
            {
                Fire.currentHealth += (0.08f * Fire.maxHealth);
                Mathf.Clamp(Fire.currentHealth, 0, Fire.maxHealth);
                fireScript.SetHealthBarValue();
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 6)
        {
            OnStageLoad();
        }
    }

    public void OnStageLoad()
    {
        if (difficulty == 4)
        {
            Fire.maxBombs = 5;

            if (Fire.currentBombs < Fire.maxBombs)
            {
                Fire.currentBombs++;
                fireScript.CountBombs();
            }

            if (Fire.currentHealth < Fire.maxHealth)
            {
                Fire.currentHealth += (0.11f * Fire.maxHealth);
                Mathf.Clamp(Fire.currentHealth, 0, Fire.maxHealth);
                fireScript.SetHealthBarValue();
            }
        }
    }


    public void Diff5Bonus()
    {
        if (difficulty == 3)
        {

        }
    }

    public void Diff6Bonus()
    {
        if (difficulty == 6)
        {

        }
    }

}
