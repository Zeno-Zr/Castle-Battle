using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;
    public float minHealth = 0;
    public float maxHealth = 100;

    public GameObject DefenceBar;
    private void Update()
    {
        if (healthAmount <= minHealth)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(float Damage)
    {
        // if the net damage dealt is < 1
        float netDamage = Damage - DefenceBar.GetComponent<DefenceBar>().defenceAmount;
        if (netDamage < 1)
        {
            healthAmount -= 1;
        }
        else
        {
            healthAmount -= netDamage;
        }

        healthBar.fillAmount = healthAmount / maxHealth;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, minHealth, maxHealth);

        healthBar.fillAmount = healthAmount / maxHealth;
    }

}
