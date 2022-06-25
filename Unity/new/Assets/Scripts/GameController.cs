using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
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

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }

    public void GoBack()
    {
        howToPlay.SetActive(false);
    }



}
