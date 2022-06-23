using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private int score = 0;
    private bool battery = false;
    public Text scoreText;
    public PowerOn powerOn;

    public HealthBar health;

    public TextMeshProUGUI DisplayInteract;

    /*
     * For items that will trigger upon touching the player. 
     * Player does not need to click the interact button to interact with it
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player dies if player collides with a trigger collider with the Death tag
        if (collision.CompareTag("Death"))
        {
            //Restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //If player collide with a trigger collider with the Coin tag, add 100 to score and destroy the coin
        if (collision.CompareTag("coin"))
        {
            score = score + 100;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }

        //If player collide with a battery, record player has the battery and thus able to power the portal on
        if (collision.CompareTag("Battery"))
        {
            battery = true;
            Destroy(collision.gameObject);
        }

        //If player collide with the portal, and player has the battery, spawns the portal
        if (collision.CompareTag("Portal") && battery == true)
        {
            // puts down a working portal in the same spot as the unpowered portal
            powerOn.TurnOnPower(collision.gameObject);
        }

        if (collision.CompareTag("HealthPotion"))
        {
            health.Healing(10);
            //Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Damage"))
        {
            health.TakeDamage(50);
            //Destroy(collision.gameObject);
        }
    }

    public void OpenInteractable()
    {
        DisplayInteract.gameObject.SetActive(true);
    }

    public void CloseInteractable()
    {
        DisplayInteract.gameObject.SetActive(false);
    }

}

