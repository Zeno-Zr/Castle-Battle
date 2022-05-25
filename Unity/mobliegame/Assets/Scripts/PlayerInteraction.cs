using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       
        }
        //If player collide with a trigger collider with the Coin tag, add 100 to score and destroy the coin
        if (collision.tag == "Coin")
        {
            score = score + 100;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
