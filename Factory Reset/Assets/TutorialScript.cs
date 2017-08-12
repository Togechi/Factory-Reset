using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {
    private Animator playAnim;
    private int state;
    private float Timer;

    private LevelManager levelManager;

    public GameObject[] tutObjects;

	// Use this for initialization
	void Start () {
        playAnim = GameObject.Find("PlayerScripts").GetComponent<Animator>();
        state = 0;
        SetOneActive(state);
        Timer = 0;
        levelManager = FindObjectOfType<LevelManager>();
	}

    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Timer > 1f && state < tutObjects.Length-1)
        {
            Timer = 0;
            state++;
            SetOneActive(state);
            print(state);
        }  else if (Input.GetKeyDown(KeyCode.Space) && Timer > 1f && state == tutObjects.Length-1)
        {
            print("Tutorial finsihed");
            levelManager.LoadLevel("Start Menu");
        }
    }
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        InputCheck();
	}

    void SetOneActive(int nextTut)
    {
        foreach (GameObject obj in tutObjects)
        {
            obj.SetActive(false);
        }

        tutObjects[nextTut].SetActive(true);
        playAnim.SetInteger("TutorialState", state);
    }
}
