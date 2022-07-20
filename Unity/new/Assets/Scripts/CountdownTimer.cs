using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 100;
    [SerializeField] private float startingTime = 100f;
    //public int totalScore = 0;

    private string lastScene;


    public GameObject IsEndless;

    public GameObject canvas;

    public GameObject timer;
    public TextMeshProUGUI seconds;
    public GameObject EndlessGameOver;
    public TextMeshProUGUI highscore;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("IsEndless") == null)
        {
            Debug.Log("spawned endless object");
            Instantiate(IsEndless, transform.position, Quaternion.identity);
            Debug.Log("changed name to IsEndless");
            FindObjectOfType<IsEndless>().name = "IsEndless";
            DontDestroyOnLoad(FindObjectOfType<IsEndless>());
        }

        if (FindObjectOfType<IsEndless>().GetComponent<IsEndless>().IsEndlessMode)
        {
            //timer.SetActive(true);
            Debug.Log("timer activate");

            if (string.IsNullOrEmpty(FindObjectOfType<IsEndless>().GetComponent<IsEndless>().lastScene))
            {
                FindObjectOfType<IsEndless>().lastScene = SceneManager.GetActiveScene().name;
                lastScene = FindObjectOfType<IsEndless>().lastScene;
                currentTime = startingTime;
                Debug.Log("Null");
            }
            else if (FindObjectOfType<IsEndless>().GetComponent<IsEndless>().lastScene == "Menu")
            {
                currentTime = startingTime;
                lastScene = FindObjectOfType<IsEndless>().lastScene;
                Debug.Log("Menu");
            }
            else
            {
                currentTime = FindObjectOfType<IsEndless>().lastCurrentTime;
                lastScene = FindObjectOfType<IsEndless>().lastScene;
                Debug.Log("continue with time");
            }
        }
        else
        {
            timer.SetActive(false);
        }

        Debug.Log("end of start");

    }

    // Update is called once per frame
    void Update()
    {
        canvas = GameObject.Find("Canvas");
        timer = canvas.transform.Find("Timer").gameObject;
        seconds = timer.transform.Find("Seconds").GetComponent<TextMeshProUGUI>();

        EndlessGameOver = canvas.transform.Find("EndlessGameOver").gameObject;
        highscore = EndlessGameOver.transform.Find("Highscore").GetComponent<TextMeshProUGUI>();

        if (lastScene != FindObjectOfType<IsEndless>().lastScene)
        {
            currentTime = FindObjectOfType<IsEndless>().lastCurrentTime;
            lastScene = FindObjectOfType<IsEndless>().lastScene;
            //AddingScore();
        }

        if (FindObjectOfType<IsEndless>().GetComponent<IsEndless>().IsEndlessMode)
        {
            //Debug.Log(currentTime);
            if (!timer.activeSelf)
            {
                timer.SetActive(true);
            }
            currentTime -= 1 * Time.deltaTime;
            ChangeTimer(currentTime);
            //Debug.Log(currentTime);

            if (currentTime <= 0)
            {
                currentTime = 0;
                EndlessGameOver.SetActive(true);
                highscore.text =  FindObjectOfType<IsEndless>().totalScore.ToString();
                Time.timeScale = 0;
                FindObjectOfType<IsEndless>().GetComponent<IsEndless>().IsEndlessMode = false;
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
        //FindObjectOfType<IsEndless>().lastCurrentTime += time;
        currentTime += time;
    }

    public void AddingScore()
    {
        FindObjectOfType<IsEndless>().totalScore += 1;
    }
}
