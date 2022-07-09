using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //add variables to save
    public int stageCompleted;
    public float currentHealth;
    public float maxHealth;
    public string lastActiveScene;
    public bool[] armors;
    public bool[] weapons;

    public string weaponTag;
    public string armorTag;

    public PlayerData(PlayerAttributes player)
    {
        //add corresponding variables for save file
        stageCompleted = player.stageCompleted;
        currentHealth = player.currentHealth;
        maxHealth = player.maxHealth;
        lastActiveScene = player.lastScene;

        weaponTag = player.weaponTag;
        armorTag = player.armorTag;
    }

    /*
        armors[0] = player.basicObtained;
        armors[1] = player.knightObtained;
        armors[2] = player.dodgeObtained;
        armors[3] = player.strongObtained;
        weapons = new bool[3];
        weapons[0] = player.pistolObtained;
        weapons[1] = player.shotgunObtained;
        weapons[2] = player.rifleObtained;
    */

}
