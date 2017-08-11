using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyNameStages : MonoBehaviour {

    public Text descriptionText;


    private Text difficultyText;
    private float currentDifficulty;

    void Start()
    {
        difficultyText = GetComponent<Text>();
    }

    void Update()
    {
        currentDifficulty = PlayerPrefsManager.GetDifficulty();


        if (currentDifficulty == 1)
        {
            difficultyText.text = "Ultra Beginner";
            difficultyText.color = new Color(105f / 255f, 255f / 255f, 112f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 2)
        {
            difficultyText.text = "Normal";
            difficultyText.color = new Color(116f / 255f, 215f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 3)
        {
            difficultyText.text = "Hard";
            difficultyText.color = new Color(64f / 255f, 89f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 4)
        {
            difficultyText.text = "Another";
            difficultyText.color = new Color(151f / 255f, 101f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 5)
        {
            difficultyText.text = "Lunatic";
            difficultyText.color = new Color(253f / 255f, 83f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 6)
        {
            difficultyText.text = "Conservationist";
            difficultyText.color = new Color(123f / 255f, 255f / 255f, 113f / 255f, 255f / 255f);
        }
    }
}
