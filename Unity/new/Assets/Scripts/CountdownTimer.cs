using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 10f;
    public float startingTime = 10f;
    public int totalScore = 0;

    public TextMeshProUGUI seconds;
    public GameObject EndlessGameOver;
    public TextMeshProUGUI highscore;

    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<IsEndless>().GetComponent<IsEndless>().IsEndlessMode)
        {
            timer.SetActive(true);
            currentTime = startingTime;
        }
        else
        {
            timer.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<IsEndless>().GetComponent<IsEndless>().IsEndlessMode)
        {
            currentTime -= 1 * Time.deltaTime;
            ChangeTimer(currentTime);

            if (currentTime <= 0)
            {
                currentTime = 0;
                EndlessGameOver.SetActive(true);
                highscore.text = totalScore.ToString();
                Time.timeScale = 0;

                //panel connects to either main menu or achievements(?)
            }

        }

    }

    //display times up and highscore (no. of seconds survived)
    public void ChangeTimer(float time)
    {
        //Seconds.text = ((int)time).ToString();
        seconds.text = ((int)Mathf.Ceil(time)).ToString();
    }

    public void AddTime(float time)
    {
        currentTime += time;
        AddingScore();
    }

    public void AddingScore()
    {
        totalScore += 1;
    }
}
