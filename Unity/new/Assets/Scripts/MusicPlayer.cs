using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Music>().StopMusic();
        FindObjectOfType<Music>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
