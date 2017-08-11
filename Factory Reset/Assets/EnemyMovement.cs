using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float horizontalSpeed = 5f;

    public float YstopPosition;



    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y>YstopPosition)
        {
            transform.position += Vector3.down * horizontalSpeed * Time.deltaTime;
        }
    }
}
