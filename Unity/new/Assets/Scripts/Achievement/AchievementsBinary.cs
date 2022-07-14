using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementsBinary
{
    public string[] Detail;
    public bool[] obtained;
    public int endlessPlayed;

    public AchievementsBinary(PlayerAchievements data)
    {
        Detail = data.Detail;
        obtained = data.obtained;
        endlessPlayed = data.endlessPlayed;
    }
}
