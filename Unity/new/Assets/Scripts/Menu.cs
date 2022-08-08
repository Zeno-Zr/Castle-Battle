using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public GameObject howToPlay;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
        FindObjectOfType<SFX>().Click();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
        FindObjectOfType<SFX>().Click();
    }

    public void StartButton()
    {
        //Load the next scene
        FindObjectOfType<IsEndless>().IsEndlessMode = false;
        DontDestroyOnLoad(FindObjectOfType<IsEndless>());

        FindObjectOfType<Music>().PlayMusic();
        FindObjectOfType<SFX>().Click();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton()
    {
        if (GameObject.Find("GameMaster") != null)
        {
            SceneManager.MoveGameObjectToScene(FindObjectOfType<GameMaster>().gameObject, SceneManager.GetActiveScene());
        }
        if (GameObject.Find("CheckpointList") != null)
        {
            SceneManager.MoveGameObjectToScene(FindObjectOfType<CheckpointList>().gameObject, SceneManager.GetActiveScene());

        }
        if (GameObject.Find("IsEndless") != null)
        {
            SceneManager.MoveGameObjectToScene(FindObjectOfType<IsEndless>().gameObject, SceneManager.GetActiveScene());
        }

        FindObjectOfType<SFX>().Click();


        //Load the main menu scene
        SceneManager.LoadScene("Menu");
    }

    public void FriendsScreenButton()
    {
        SceneManager.LoadSceneAsync("FriendsAndAchievements");
        FindObjectOfType<SFX>().Click();
    }

    public void SandBoxMinigame()
    {
        //Load the sandbox select scene
        SceneManager.LoadScene("SandBoxEntrence");
        FindObjectOfType<SFX>().Click();
    }

    public void HowToPlayOpen()
    {
        howToPlay.SetActive(true);
        FindObjectOfType<SFX>().Click();
    }

    public void HowToPlayFalse()
    {
        howToPlay.SetActive(false);
        FindObjectOfType<SFX>().Click();
    }

    public void EndlessMiniGame()
    {
        FindObjectOfType<IsEndless>().IsEndlessMode = true;
        FindObjectOfType<IsEndless>().lastScene = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(FindObjectOfType<IsEndless>());

        RandomSelector();
        FindObjectOfType<SFX>().Click();
    }

    public void RandomSelector()
    {
        int firstindex = Random.Range(1, 10);
        int resultingindex = 1;

        switch (firstindex)
        {
            case 1:
                resultingindex = 4;
                break;
            case 2:
                resultingindex = 5;
                break;
            case 3:
                resultingindex = 6;
                break;

            case 4:
                resultingindex = 8;
                break;
            case 5:
                resultingindex = 9;
                break;
            case 6:
                resultingindex = 10;
                break;

            case 7:
                resultingindex = 12;
                break;
            case 8:
                resultingindex = 13;
                break;
            case 9:
                resultingindex = 14;
                break;

            case 10:
                resultingindex = 16;
                break;

            default:
                Debug.Log("failed");
                break;
        }

        SceneManager.LoadScene(resultingindex);

    }
}
