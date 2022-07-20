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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void StartButton()
    {
        //Load the next scene
        FindObjectOfType<IsEndless>().IsEndlessMode = false;
        DontDestroyOnLoad(FindObjectOfType<IsEndless>());

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


        //Load the main menu scene
        SceneManager.LoadScene("Menu");
    }

    public void FriendsScreenButton()
    {
        SceneManager.LoadSceneAsync("FriendsAndAchievements");
    }

    public void SandBoxMinigame()
    {
        //Load the sandbox select scene
        SceneManager.LoadScene("SandBoxEntrence");
    }

    public void HowToPlayOpen()
    {
        howToPlay.SetActive(true);
    }

    public void HowToPlayFalse()
    {
        howToPlay.SetActive(false);
    }

    public void EndlessMiniGame()
    {
        FindObjectOfType<IsEndless>().IsEndlessMode = true;
        FindObjectOfType<IsEndless>().lastScene = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(FindObjectOfType<IsEndless>());

        int index = Random.Range(3, 12);
        SceneManager.LoadScene(index);
    }
}
