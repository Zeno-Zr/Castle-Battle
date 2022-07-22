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

        int index = Random.Range(3, 12);
        SceneManager.LoadScene(index);
        FindObjectOfType<SFX>().Click();
    }
}
