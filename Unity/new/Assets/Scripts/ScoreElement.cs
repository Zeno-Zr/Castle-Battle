using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text scoreText;

    string friendUID;

    public void NewScoreElement(string _username, int _score)
    {
        usernameText.text =  _username;
        scoreText.text = _score.ToString();
    }

    public void RecordFriendUID(string UID)
    {
        friendUID = UID;
    }

    public void RemoveFriendUID()
    {
        GameObject.Find("FirebaseManager").GetComponent<FirebaseManager>().RemoveFriendsButton(friendUID);
    }
}
