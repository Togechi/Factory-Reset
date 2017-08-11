using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private Text totalText;
    public Text killText;
    public Text grazeText;

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        totalText = GetComponent<Text>();
        scoreManager = FindObjectOfType<ScoreManager>();

        if (killText && grazeText)
        {
            totalText.text = scoreManager.TotalScore().ToString();
            killText.text = ScoreManager.killScore.ToString();
            grazeText.text = ScoreManager.grazeScore.ToString();
        } else
        {
            Debug.Log("No kill and graze text");
        }
    }
	
    public void ScoreUpdate ()
    {
        totalText.text = scoreManager.TotalScore().ToString();
    }
}
