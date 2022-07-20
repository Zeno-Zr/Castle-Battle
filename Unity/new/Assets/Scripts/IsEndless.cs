using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEndless : MonoBehaviour
{
    public bool IsEndlessMode = false;
    public string lastScene;

    public float lastCurrentTime = 0;
    public int totalScore = 0;

    //need the IsEndless object in the scene to load the next scene
}
