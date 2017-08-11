using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {

    public GameObject quickFireProjectile;
    public float quickFireSpeed;
    public float quickFireRate;

    public GameObject heavyFireProjectile;
    public float heavyFireSpeed;
    public float heavyFireRate;

    public GameObject bombProjectile;
    public float bombSpeed;
    public float bombRate;
    public static float currentBombs;
    public static float maxBombs = 5;

    public Text BombCounter;

    private int fireType = 0;

    public static float currentHealth = 400f;
    public static float maxHealth = 400f;

    public Slider healthBar;

    public AudioClip QuickShot;
    public AudioClip HeavyShot;
    public AudioClip BombShot;

    private float Timer;
    public float quickCooldown;
    public float heavyCooldown;
    public float bombCooldown;

    private float previousValue= 0;
    private float healthDifference;

    private BonusText bonusText;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        previousValue = currentHealth;
        healthBar.value = healthValue();

        //InvokeRepeating("CheckForHealthChange", 0.00001f, 0.5f);
        maxBombs = 5;
        currentBombs = maxBombs;
        BombCounter.text = "Bombs: " + currentBombs;

        bonusText = FindObjectOfType<BonusText>();
	}

    private void QuickFire ()
    {
        Vector3 offsetY = new Vector3(0, 1, 0);
        Vector3 offsetX = new Vector3(1, 0, 0);
        GameObject beam = Instantiate(quickFireProjectile, transform.position + offsetY + offsetX/3, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, quickFireSpeed, 0);
        GameObject beam2 = Instantiate(quickFireProjectile, transform.position + offsetY - offsetX/3, Quaternion.identity) as GameObject;
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

    private void BombFire ()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(bombProjectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bombSpeed, 0);
        AudioSource.PlayClipAtPoint(BombShot, transform.position, 1f);
    }


    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        InputCheck();

        if (fireType == 0)
        {
            CancelInvoke();
        }
    }

    private void InputCheck ()
    {
        if (fireType == 0  && Input.GetKeyDown(KeyCode.D) && Timer>quickCooldown)
        {
            fireType = 1;
            InvokeRepeating("QuickFire", 0.00001f, quickFireRate);
            Timer = 0;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            fireType = 0;
        }

        else if (fireType == 0 && Input.GetKeyDown(KeyCode.S) && Timer>heavyCooldown)
        {
            fireType = 2;
            InvokeRepeating("HeavyFire", 0.00001f, heavyFireRate);
            Timer = 0;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            fireType = 0;
        }

        else if (fireType == 0 && Input.GetKeyDown(KeyCode.Space) && Timer > bombCooldown && currentBombs >= 1 && currentBombs <= maxBombs)
        {
            fireType = 1;
            InvokeRepeating("BombFire", 0.00001f, bombRate); Timer = 0;
            currentBombs--;
            CountBombs();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            fireType = 0;
        }

    }

    public void CountBombs()
    {
        BombCounter.text = "Bombs: " + currentBombs;
    }

    public float healthValue()
    {
        return currentHealth / maxHealth;
    }

    public void SetHealthBarValue ()
    {
        CheckForHealthChange();
        healthBar.value = healthValue();
    }

    private void CheckForHealthChange()
    {
        if (previousValue != currentHealth)
        {
            healthDifference = currentHealth - previousValue;
            //bonusText.FlashBonus(healthDifference / maxHealth * 100);
            previousValue = currentHealth;

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyProjectile missile = collider.gameObject.GetComponent<EnemyProjectile>();
        if (missile)
        {
            Debug.Log("Player collided with the missile");
            currentHealth -= missile.GetDamage();
            SetHealthBarValue();
            missile.Hit();
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                level.LoadLevel("Lose");
            }
        }
    }

}



