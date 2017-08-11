using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusText : MonoBehaviour {

    private Text bonusText;
    private Animator anim;

    public bool Enabled;

    private void Start()
    {
        bonusText = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    public void FlashBonus(float bonus)
    {
        if (Enabled)
        {
            if (bonus > 0)
            {
                bonusText.text = bonus.ToString() + "%";
                bonusText.color = Color.green;
                anim.SetTrigger("ValueChanged");
            }
            else if (bonus < 0)
            {
                bonusText.text = bonus.ToString() + "%";
                bonusText.color = Color.red;
                anim.SetTrigger("ValueChanged");
            }
        }
        else
        {
          
        }
    }
}
