using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    PlayerAchievements savedAchievements;

    // Start is called before the first frame update
    void Start()
    {
        savedAchievements = GetComponent<PlayerAchievements>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "ScifiNew 1")
        {
            savedAchievements.obtained[0] = true;
        }
        if (scene.name == "SandLevel 1")
        {
            savedAchievements.obtained[1] = true;
        }
        if (scene.name == "FinalLevel")
        {
            savedAchievements.obtained[2] = true;
        }
        if (scene.name == "SandBoxEntrence")
        {
            savedAchievements.obtained[7] = true;
        }
    }

    //Called after every Endless attempt
    void EndlessScoreCheck()
    {
        savedAchievements.endlessPlayed += 1;
        TMP_Text scoreText = GameObject.Find("EndlessGameOver/Highscore").GetComponent<TMP_Text>();
        int score = int.Parse(scoreText.text); 
        if (score >= 10)
        {
            savedAchievements.obtained[3] = true;
        }
        if (score >= 50)
        {
            savedAchievements.obtained[4] = true;
        }
        if (score >= 100)
        {
            savedAchievements.obtained[5] = true;
        }
        if (savedAchievements.endlessPlayed >= 3)
        {
            savedAchievements.obtained[6] = true;
        }
    }

    //Called after loading Friends scene
    void FriendCheck()
    {
        if (GameObject.Find("Friends_UI/screen/Elements/Scroll View/Viewport/Content").transform.childCount != 0)
        {
            savedAchievements.obtained[8] = true;
        }
    }

    //Called in enemy death method
    void KilledEnemy()
    {
        savedAchievements.obtained[9] = true;
    }

    public void pressShareButton()
    {
        StartCoroutine(buttonRunning());
    }

    IEnumerator buttonRunning()
    {
        EndlessScoreCheck();
        int submitScore = int.Parse(GameObject.Find("EndlessGameOver/Highscore").GetComponent<TMP_Text>().text);
        SceneManager.LoadScene("FriendsAndAchievements");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "FriendsAndAchievements");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);
        GameObject.Find("FirebaseManager").GetComponent<FirebaseManager>().SaveDataButton(submitScore);
    }
}
