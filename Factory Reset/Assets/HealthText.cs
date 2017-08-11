using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    private Fire fireScript;
    private Text healthText;

    private void Start()
    {
        healthText = GetComponent<Text>();
        fireScript = FindObjectOfType<Fire>();
    }

    private void Update()
    {
        healthText.text = Mathf.Round((Mathf.Clamp(Fire.currentHealth / Fire.maxHealth * 100, 0, 100))).ToString() + "%";
    }
}
