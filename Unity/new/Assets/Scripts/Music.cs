using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource menu;
    public AudioSource basicLevels;
    public AudioSource sciFiLevels;
    public AudioSource sandLevels;
    public AudioSource finalBoss;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Menu").GetComponent<AudioSource>();
        basicLevels = GameObject.Find("BasicLevels").GetComponent<AudioSource>();
        sciFiLevels = GameObject.Find("SciFiLevels").GetComponent<AudioSource>();
        sandLevels = GameObject.Find("SandLevels").GetComponent<AudioSource>();
        finalBoss = GameObject.Find("FinalBoss").GetComponent<AudioSource>();

        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {

        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Debug.Log("played menu");
            Menu();
        }
        else if (SceneManager.GetActiveScene().name == "BasicLevel1"
            || SceneManager.GetActiveScene().name == "BasicLevel2"
            || SceneManager.GetActiveScene().name == "BasicLevel3"
            || SceneManager.GetActiveScene().name == "Story1")
        {
            Debug.Log("played basic");
            BasicLevels();
        }
        else if (SceneManager.GetActiveScene().name == "ScifiNew 1"
            || SceneManager.GetActiveScene().name == "ScifiNew 2"
            || SceneManager.GetActiveScene().name == "ScifiNew 3"
            || SceneManager.GetActiveScene().name == "Story2")

        {
            Debug.Log("played scifi");
            SciFiLevels();
        }
        else if (SceneManager.GetActiveScene().name == "SandLevel 1"
            || SceneManager.GetActiveScene().name == "SandLevel 2"
            || SceneManager.GetActiveScene().name == "SandLevel 3"
            || SceneManager.GetActiveScene().name == "Story3")
        {
            Debug.Log("played sand");
            SandLevels();
        }
        else if (SceneManager.GetActiveScene().name == "FinalLevel")
        {
            Debug.Log("played final");
            FinalBoss();
        }
        else
        {
            Menu();
        }
    }

    public void StopMusic()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.Stop();
    }

    public void Menu()
    {
        menu.PlayOneShot(menu.clip);
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.Stop();
    }

    public void BasicLevels()
    {
        menu.Stop();
        basicLevels.PlayOneShot(basicLevels.clip);
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.Stop();

    }

    public void SciFiLevels()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.PlayOneShot(sciFiLevels.clip);
        sandLevels.Stop();
        finalBoss.Stop();

    }

    public void SandLevels()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.PlayOneShot(sandLevels.clip);
        finalBoss.Stop();

    }

    public void FinalBoss()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.PlayOneShot(finalBoss.clip);
    }
}
