using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayHealth : MonoBehaviour
{
    [Header("Player Health")]
    public float maxHealth;
    public float curHealth;
    public float delayHealth;
    public float dropSpeed;
    public float timeDelay, healthDifference;
    public bool check;
    public Slider healthBar, delayBar;
    public Image healthFill, delayFill;
    // Update is called once per frame
    void Update()
    {
        healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        if (delayHealth > curHealth)
        {
            timeDelay -= Time.deltaTime;
            if (timeDelay <= 0)
            {
                if (!check)
                {
                    healthDifference = delayHealth - curHealth;
                    check = true;
                }
                //dropSpeed = healthDifference / 4;
                //Debug.Log(dropSpeed * Time.deltaTime);
                delayHealth -= (healthDifference/dropSpeed) * Time.deltaTime;

            }

        }
        else
        {
            check = false;
            timeDelay = 1;
        }
        delayBar.value = Mathf.Clamp01(delayHealth / maxHealth);
        HealthController();
    }
    void HealthController()
    {
        if (curHealth <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
        }
        else if (!healthFill.enabled && curHealth > 0)
        {
            healthFill.enabled = true;
        }
        if (delayHealth <= 0 && delayFill.enabled)
        {
            delayFill.enabled = false;
        }
        if (delayHealth < curHealth)
        {
            delayFill.enabled = true;
            delayHealth = curHealth;
            delayBar.value = healthBar.value;
        }
    }

    void DelayedDrop()
    {

    }

    void PlayerHandler()
    {

    }
}
