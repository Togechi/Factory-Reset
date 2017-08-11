using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDeath : MonoBehaviour {

    public static bool previousWaveDead = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount < 1)
        {
            Destroy(gameObject);
            previousWaveDead = true;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }


}
