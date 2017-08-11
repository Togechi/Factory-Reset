using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int killScore;
    public static int grazeScore;
    public static int deadCount;

    public ScoreDisplay scoreDisplay;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        deadCount = 0;
	}

    public void ResetScore ()
    {
        killScore = 0;
        grazeScore = 0;
    }

    private void OnLevelWasLoaded(int level)
    {

    }

    // Update is called once per frame
    void Update () {

	}

    public float TotalScore()
    {
        return killScore + grazeScore;
    }

    public void AddScore(int points)    
    {
        killScore += points;
        scoreDisplay.ScoreUpdate();
    }

    public void AddGrazeScore(int grazePoints)
    {
        grazeScore += grazePoints;
        scoreDisplay.ScoreUpdate();
    }
}
