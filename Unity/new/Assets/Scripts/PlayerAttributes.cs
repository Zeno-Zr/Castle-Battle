using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttributes : MonoBehaviour
{
    //add variables to save
    public int stageCompleted = 0;
    public float currentHealth = 100;
    public float maxHealth = 100;
    public string lastScene;


    public string weaponTag;
    public string armorTag;


    public void SavePlayer()
    {
        //add functions to get values or write directly
        UpdateArmor();
        UpdateHealth();
        UpdateWeapon();
        UpdateStageComplete();
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
        weaponTag = data.weaponTag;
        armorTag = data.armorTag;
        lastScene = data.lastActiveScene;
    }


    private void UpdateWeapon()
    {
        weaponTag = FindObjectOfType<AttackValue>().WeaponTag;
    }

    private void UpdateArmor()
    {
        armorTag = FindObjectOfType<DefenceBar>().ArmorTag;
    }

    private void UpdateHealth()
    {
        currentHealth = FindObjectOfType<HealthBar>().healthAmount;
        maxHealth = FindObjectOfType<HealthBar>().maxHealth;
    }

    public void UpdateStageComplete()
    {

    }
}


/*
     //armors obtained in story mode
    public bool basicObtained = false;
    public bool knightObtained = false;
    public bool dodgeObtained = false;
    public bool strongObtained = false;

    //weapons obtained in story mode
    public bool pistolObtained = false;
    public bool shotgunObtained = false;
    public bool rifleObtained = false;


        string armor = FindObjectOfType<DefenceBar>().ArmorTag;
        switch (armor)
        {
            case "Armor_Basic":
                basicObtained = true;
                knightObtained = false;
                dodgeObtained = false;
                strongObtained = false;
                break;
            case "Armor_Knight":
                basicObtained = false;
                knightObtained = true;
                dodgeObtained = false;
                strongObtained = false;
                break;
            case "Armor_Dodge":
                basicObtained = false;
                knightObtained = false;
                dodgeObtained = true;
                strongObtained = false;
                break;
            case "Armor_Strong":
                basicObtained = false;
                knightObtained = false;
                dodgeObtained = false;
                strongObtained = true;
                break;
            default:
                basicObtained = false;
                knightObtained = false;
                dodgeObtained = false;
                strongObtained = false;
                break;
        }

        string weapon = FindObjectOfType<AttackValue>().WeaponTag;
        switch (weapon)
        {
            case "Weapon_Pistol":
                pistolObtained = true;
                shotgunObtained = false;
                rifleObtained = false;
                break;
            case "Weapon_Shotgun":
                pistolObtained = false;
                shotgunObtained = true;
                rifleObtained = false;
                break;
            case "Weapon_Rifle":
                pistolObtained = false;
                shotgunObtained = false;
                rifleObtained = true;
                break;
            default:
                pistolObtained = false;
                shotgunObtained = false;
                rifleObtained = false;
                break;
        }


      basicObtained = data.armors[0];
        knightObtained = data.armors[1];
        dodgeObtained = data.armors[2];
        strongObtained = data.armors[3];

        pistolObtained = data.weapons[0];
        shotgunObtained = data.weapons[1];
        rifleObtained = data.weapons[2];


*/



