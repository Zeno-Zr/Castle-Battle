using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsDontDestroy : MonoBehaviour
{
    static GameObject instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
        } else
        {
            Destroy(gameObject);
        }
    }
}
