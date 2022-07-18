using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessShareButton : MonoBehaviour
{
    public void pressButton()
    {
        GameObject.Find("AchievementsManager").GetComponent<AchievementManager>().pressShareButton();
    }
}
