using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    private void Awake()
    {
        if (soundManager != null && soundManager != false)
        {
            Destroy(this.gameObject);
            return;
        }

        soundManager = this;
        DontDestroyOnLoad(this);
    }
}
