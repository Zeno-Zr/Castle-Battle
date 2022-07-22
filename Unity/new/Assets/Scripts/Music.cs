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
            || SceneManager.GetActiveScene().name == "BasicLevel3")
        {
            Debug.Log("played basic");
            BasicLevels();
        }
        else if (SceneManager.GetActiveScene().name == "SciFiNew 1"
            || SceneManager.GetActiveScene().name == "SciFiNew 2"
            || SceneManager.GetActiveScene().name == "SciFiNew 3")
        {
            Debug.Log("played scifi");
            SciFiLevels();
        }
        else if (SceneManager.GetActiveScene().name == "SandLevel 1"
            || SceneManager.GetActiveScene().name == "SandLevel 2"
            || SceneManager.GetActiveScene().name == "SandLevel 3")
        {
            Debug.Log("played sand");
            SandLevels();
        }
        else if (SceneManager.GetActiveScene().name == "FinalLevel")
        {
            Debug.Log("played final");
            FinalBoss();
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
        menu.PlayOneShot(menu.GetComponent<AudioSource>().clip);
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.Stop();
    }

    public void BasicLevels()
    {
        menu.Stop();
        basicLevels.PlayOneShot(basicLevels.GetComponent<AudioSource>().clip);
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.Stop();

    }

    public void SciFiLevels()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.PlayOneShot(sciFiLevels.GetComponent<AudioSource>().clip);
        sandLevels.Stop();
        finalBoss.Stop();

    }

    public void SandLevels()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.PlayOneShot(sandLevels.GetComponent<AudioSource>().clip);
        finalBoss.Stop();

    }

    public void FinalBoss()
    {
        menu.Stop();
        basicLevels.Stop();
        sciFiLevels.Stop();
        sandLevels.Stop();
        finalBoss.PlayOneShot(finalBoss.GetComponent<AudioSource>().clip);
    }
}
