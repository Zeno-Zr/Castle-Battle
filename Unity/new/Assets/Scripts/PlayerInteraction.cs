using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private int score = 0;
    private bool battery = false;
    public Text scoreText;
    public PowerOn powerOn;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player dies if player collides with a trigger collider with the Death tag
        if (collision.tag == "Death")
        {
            //Restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        //Player to proceed to next level if player collides with a trigger collider with the Finish tag
        if (collision.tag == "Finish")
        {
            //Load next level
            //Debug.Log("portal is working");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        //If player collide with a trigger collider with the Coin tag, add 100 to score and destroy the coin
        if (collision.tag == "Coin")
        {
            score = score + 100;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }

        //If player collide with a battery, record player has the battery and thus able to power the portal on
        if (collision.tag == "Battery")
        {
            battery = true;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Portal")
        {
            if (battery == true)
            {
                powerOn.TurnOnPower(gameObject);
                Destroy(collision.gameObject);
            }
        }
       


    }
}
