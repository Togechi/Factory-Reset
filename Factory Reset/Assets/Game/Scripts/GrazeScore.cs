using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeScore : MonoBehaviour {

    private ScoreManager scoreManager;
    public int grazePoints = 999;

    // Use this for initialization
    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    { 
            EnemyProjectile missile = collider.gameObject.GetComponent<EnemyProjectile>();
            if (missile)
            {
                scoreManager.AddGrazeScore(grazePoints);
            }
    }
}
