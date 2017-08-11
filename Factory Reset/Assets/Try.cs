using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour {

    public float health = 150;
    public int valueOfEnemy = 150;
    private Animator anim;

    private DifficultyBonus difficultyBonus;
    private ScoreManager scoreManager;

    private void Start()
    {
        difficultyBonus = FindObjectOfType<DifficultyBonus>();
        anim = GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            anim.SetTrigger("Damaged");
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                anim.SetBool("Dead", true);
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void StartOfDeathAnimation ()
    {
        ScoreManager.deadCount++;
        scoreManager.AddScore(valueOfEnemy);
        difficultyBonus.OnEnemyKilled();
    }
}
