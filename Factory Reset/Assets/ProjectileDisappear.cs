using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDisappear : MonoBehaviour {
    private float Timer;
    public float disappearAfter = 4f;

	// Use this for initialization
	void Start () {
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (Timer >= disappearAfter)
        {
            Destroy(gameObject);
        }
	}
}
