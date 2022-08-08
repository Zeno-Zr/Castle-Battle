using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (item.name == "Wait")
            {
                new WaitForSecondsRealtime(2);
            }
            else
            {
                IsDoneWithDisplaying = false;
                yield return new WaitUntil(() => IsDoneWithDisplaying == true);
                Debug.Log(item.name);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }



    // Update is called once per frame
    void Update()
    {

    }

}
