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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton()
    {
        //Load the main menu scene
        SceneManager.LoadScene("Menu");
    }

    public void FriendsScreenButton()
    {
        SceneManager.LoadSceneAsync("FriendsAndAchievements");
    }

    public void TempScorePageButton()
    {
        //Load the temp score scene
        SceneManager.LoadScene("UploadScore");
    }

    public void HowToPlayOpen()
    {
        howToPlay.SetActive(true);
    }

    public void HowToPlayFalse()
    {
        howToPlay.SetActive(false);
    }
}
