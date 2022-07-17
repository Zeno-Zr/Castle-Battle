using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAchievements : MonoBehaviour
{
    public string[] Detail;
    public bool[] obtained;
    public int endlessPlayed = 0;

    void Awake()
    {
        Detail = new string[10];
        obtained = new bool[10];
        
        Detail[0] = "Complete Earth Levels";
        Detail[1] = "Complete Scifi Levels";
        Detail[2] = "Complete Desert Levels";
        Detail[3] = "Score Above 10 in Endless";
        Detail[4] = "Score Above 50 in Endless";
        Detail[5] = "Score Above 100 in Endless";
        Detail[6] = "Play Endless 3 Times";
        Detail[7] = "Explore Sandbox";
        Detail[8] = "Add a Friend";
        Detail[9] = "Kill an Enemy";
        for (int i = 0; i < Detail.Length; i++)
        {
            obtained[i] = false;
        }
    }

    void start()
    {
        LoadPlayer();
        InvokeRepeating("SavePlayer", 0f, 60f);
    }

    public void SavePlayer()
    {
        SaveAchievements.SavePlayer(this);
    }

    // Update is called once per frame
    public void LoadPlayer()
    {
        AchievementsBinary data = SaveAchievements.LoadPlayer();
        for (int i = 0; i < data.Detail.Length; i++)
        {
            obtained[i] = data.obtained[i];
            Detail[i] = data.Detail[i];
        }
        endlessPlayed = data.endlessPlayed;
    }
}
