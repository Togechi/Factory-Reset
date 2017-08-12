using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFire : MonoBehaviour {

    public GameObject quickFireProjectile;
    public float quickFireSpeed;
    public float quickFireRate;

    public GameObject heavyFireProjectile;
    public float heavyFireSpeed;
    public float heavyFireRate;

    public GameObject bombProjectile;
    public float bombSpeed;
    public float bombRate;

    public Text BombCounter;

    private int fireType = 0;

    public static float currentHealth = 400f;
    public static float maxHealth = 400f;

    public Slider healthBar;

    public AudioClip QuickShot;
    public AudioClip HeavyShot;
    public AudioClip BombShot;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void CancelFire ()
    {
        CancelInvoke();
    }

    private void TutorialQuickFire()
    {
        InvokeRepeating("QuickFire", 0.00001f, quickFireRate);
    }

    private void TutorialHeavyFire()
    {
        InvokeRepeating("HeavyFire", 0.00001f, heavyFireRate);
    }

    private void TutorialBombkFire()
    {
        InvokeRepeating("BombFire", 0.00001f, bombRate);
    }

    private void QuickFire()
    {
        Vector3 offsetY = new Vector3(0, 1, 0);
        Vector3 offsetX = new Vector3(1, 0, 0);
        GameObject beam = Instantiate(quickFireProjectile, transform.position + offsetY + offsetX / 3, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, quickFireSpeed, 0);
        GameObject beam2 = Instantiate(quickFireProjectile, transform.position + offsetY - offsetX / 3, Quaternion.identity) as GameObject;
        beam2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, quickFireSpeed, 0);
        AudioSource.PlayClipAtPoint(QuickShot, transform.position, 0.5f);
    }

    private void HeavyFire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(heavyFireProjectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, heavyFireSpeed, 0);
        AudioSource.PlayClipAtPoint(HeavyShot, transform.position, 0.5f);
    }

    private void BombFire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(bombProjectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bombSpeed, 0);
        AudioSource.PlayClipAtPoint(BombShot, transform.position, 1f);
    }
}
