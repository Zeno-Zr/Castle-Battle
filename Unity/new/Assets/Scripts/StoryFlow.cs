using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryFlow : MonoBehaviour
{
    public GameObject[] parts;
    int indexOfParts = 0;
    int failsafe = 0;
    public bool IsDoneWithDisplaying;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Story());
        Debug.Log("finish");

    }
    IEnumerator Story()
    {
        foreach (GameObject item in parts)
        {
            item.SetActive(true);
            IsDoneWithDisplaying = false;
            yield return new WaitUntil(() => IsDoneWithDisplaying == true);
            Debug.Log(item.name);
        }

    }



    // Update is called once per frame
    void Update()
    {

    }

}
