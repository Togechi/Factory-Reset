using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyName : MonoBehaviour {

    public Text descriptionText;
    public Text typeText;
    public Text modeText;

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

            descriptionText.text = "Easy SS";
            descriptionText.color = new Color(201f / 255f, 255f / 255f, 203f / 255f, 255f / 255f);

            typeText.text = "Standard";
            typeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            modeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 2)
        {
            difficultyText.text = "Normal";
            difficultyText.color = new Color(116f / 255f, 215f / 255f, 255f / 255f, 255f / 255f);

            descriptionText.text = "Skill = Goldfish";
            descriptionText.color = new Color(165f / 255f, 192f / 255f, 255f / 255f, 255f / 255f);

            typeText.text = "Standard";
            typeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            modeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 3)
        {
            difficultyText.text = "Hard";
            difficultyText.color = new Color(64f / 255f, 89f / 255f, 255f / 255f, 255f / 255f);

            descriptionText.text = "Uhh you're alright";
            descriptionText.color = new Color(75f / 255f, 136f / 255f, 255f / 255f, 255f / 255f);

            typeText.text = "Standard";
            typeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            modeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 4)
        {
            difficultyText.text = "Another";
            difficultyText.color = new Color(151f / 255f, 101f / 255f, 255f / 255f, 255f / 255f);

            descriptionText.text = "N E V E R G I V E U P";
            descriptionText.color = new Color(205f / 255f, 116f / 255f, 236f / 255f, 255f / 255f);

            typeText.text = "Standard";
            typeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            modeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 5)
        {
            difficultyText.text = "Lunatic";
            difficultyText.color = new Color(253f / 255f, 83f / 255f, 255f / 255f, 255f / 255f);

            descriptionText.text = "FOUR DIMENSIONS";
            descriptionText.color = new Color(243f / 255f, 73f / 255f, 87f / 255f, 255f / 255f);

            typeText.text = "Standard";
            typeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
            modeText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        }
        else if (currentDifficulty == 6)
        {
            difficultyText.text = "Conservationist";
            difficultyText.color = new Color(123f / 255f, 255f / 255f, 113f / 255f, 255f / 255f);

            descriptionText.text = "Don't worry, you won't go unpunished for your actions";
            descriptionText.color = new Color(231f / 255f, 134f / 255f, 212f / 255f, 255f / 255f);

            typeText.text = "Special";
            typeText.color = new Color(231f / 255f, 134f / 255f, 212f / 255f, 255f / 255f);
            modeText.color = new Color(231f / 255f, 134f / 255f, 212f / 255f, 255f / 255f);
        }
    }
}
