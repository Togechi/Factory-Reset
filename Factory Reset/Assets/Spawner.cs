using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Waves;

    private int nextWave;
    private float Timer;
    public float[] respawnTime;

    CheckForDeath wave;

    public DifficultyBonus difficultyBonus;

    private void Start()
    {
        nextWave = 0;
        GetComponent<CheckForDeath>();
        Respawn(Waves[nextWave]);
    }

    // Update is called once per frame
    void Update () {
        Timer += Time.deltaTime;
        CheckForDeath wave = gameObject.GetComponent<CheckForDeath>();

        if (nextWave >= Waves.Length-1 && CheckForDeath.previousWaveDead == true)
        {
            LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            PlayerData.InStage = false;
            level.LoadNextLevel();
        }

        if (Timer > respawnTime[nextWave] && CheckForDeath.previousWaveDead == true)
            // OK M8 SO I WANT U TO HAVE IT SO IF THEYRE DEAD INSTANTLY RESPAWN NEXT ONE OR HAVE A COMPLETED WAVE 1 SCREEN (USE A PUBLIC VOID OR SOMETHNG OK)
        {
            Respawn(Waves[nextWave]);
        }
	}

    void Respawn (GameObject waveObject)
    {
        GameObject Wave = Instantiate(waveObject, waveObject.transform.position, Quaternion.identity) as GameObject;
        Timer = 0;
        nextWave++;
        CheckForDeath.previousWaveDead = false;
        difficultyBonus.OnWaveKilled();
    }
}
