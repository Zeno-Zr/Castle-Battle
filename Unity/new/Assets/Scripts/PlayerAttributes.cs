using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttributes : MonoBehaviour
{
    //add variables to save
    public int stageCompleted = 0;
    public int currentHealth = 50;
    public int maxHealth = 100;
    public string lastScene;

    //armors obtained in story mode
    public bool basicObtained = false;
    public bool knightObtained = false;
    public bool dodgeObtained = false;
    public bool strongObtained = false;

    //weapons obtained in story mode
    public bool pistolObtained = false;
    public bool shotgunObtained = false;
    public bool rifleObtained = false;

    public void SavePlayer()
    {
        //add functions to get values or write directly
        lastScene = SceneManager.GetActiveScene().name;
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        //add corresponding variable to load from save file
        PlayerData data = SaveSystem.LoadPlayer();
        stageCompleted = data.stageCompleted;
        currentHealth = data.currentHealth;
        maxHealth = data.maxHealth;
        lastScene = data.lastActiveScene;

        basicObtained = data.armors[0];
        knightObtained = data.armors[1];
        dodgeObtained = data.armors[2];
        strongObtained = data.armors[3];

        pistolObtained = data.weapons[0];
        shotgunObtained = data.weapons[1];
        rifleObtained = data.weapons[2];
    }
}
