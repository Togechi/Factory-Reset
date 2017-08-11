using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour
{

    public Slider volumeSlider;
    public Slider diffSlider;
    public LevelManager2 levelManager;

    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();

        if (!musicManager)
        {
            Debug.LogWarning("No music player found by Options Controller");
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (musicManager)
        {
            musicManager.ChangeVolume(volumeSlider.value);
        }
        PlayerPrefsManager.SetDifficulty(diffSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(diffSlider.value);

        levelManager.LoadLevel("Start Menu");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        diffSlider.value = 2f;
    }
}