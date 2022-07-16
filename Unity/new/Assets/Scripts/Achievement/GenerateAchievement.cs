using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAchievement : MonoBehaviour
{
    [SerializeField] Transform AchievementContent;
    [SerializeField] GameObject AchievementPrefab;

    PlayerAchievements _achievements;

    // Start is called before the first frame update
    void Start()
    {
        _achievements = GameObject.Find("AchievementsManager").GetComponent<PlayerAchievements>();
        Debug.Log("Referencing " + _achievements);
    }

    public void AchievementsTab()
    {
        foreach (Transform child in AchievementContent.transform)
        {
            Destroy(child.gameObject);
        }

        int achievementsLength = _achievements.Detail.Length;
        Debug.Log("Generating " + achievementsLength + " Achievement Elements");

        for (int i = 0; i < achievementsLength; i++)
        {
            GameObject AchievementElement = Instantiate(AchievementPrefab, AchievementContent);
            AchievementElement.GetComponent<AchievementStatus>().SetName(_achievements.Detail[i]);
            AchievementElement.GetComponent<AchievementStatus>().Achieved = _achievements.obtained[i];
            Debug.Log("Generated " + _achievements.Detail[i] + " Achievement");
        }
    }
}
