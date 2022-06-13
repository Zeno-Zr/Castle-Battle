using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int stageCompleted;
    public int currentHealth;
    public int maxHealth;
    public bool[] armors;
    public bool[] weapons;

    public PlayerData (PlayerAttributes player)
    {
        stageCompleted = player.stageCompleted;
        currentHealth = player.currentHealth;
        maxHealth = player.maxHealth;
        armors = new bool[4];
        armors[0] = player.basicObtained;
        armors[1] = player.knightObtained;
        armors[2] = player.dodgeObtained;
        armors[3] = player.strongObtained;
        weapons = new bool[3];
        weapons[0] = player.pistolObtained;
        weapons[1] = player.shotgunObtained;
        weapons[2] = player.rifleObtained;
    }
}
