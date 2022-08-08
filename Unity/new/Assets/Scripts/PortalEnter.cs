using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : Interactable
{

    // when player taps the interact button while touching the working portal, brings the player to the next scene
    public override void Interact()
    {
        FindObjectOfType<PlayerAttributes>().SavePlayer();
        Debug.Log("portal is working");

        SceneManager.MoveGameObjectToScene(FindObjectOfType<GameMaster>().gameObject, SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(FindObjectOfType<CheckpointList>().gameObject, SceneManager.GetActiveScene());
        Object.Destroy(FindObjectOfType<GameMaster>());
        Object.Destroy(FindObjectOfType<CheckpointList>());

        DontDestroyOnLoad(FindObjectOfType<IsEndless>());

        if (FindObjectOfType<IsEndless>().IsEndlessMode)
        {
            Debug.Log("next endless");
            FindObjectOfType<IsEndless>().IsEndlessMode = true;

            FindObjectOfType<CountdownTimer>().AddTime(30);
            FindObjectOfType<CountdownTimer>().AddingScore();

            FindObjectOfType<IsEndless>().lastCurrentTime = FindObjectOfType<CountdownTimer>().currentTime;

            FindObjectOfType<IsEndless>().lastScene = SceneManager.GetActiveScene().name;

            RandomSelector();

        }
        else
        {
            Debug.Log("next scene");
            FindObjectOfType<IsEndless>().IsEndlessMode = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void RandomSelector()
    {
        int firstindex = Random.Range(1, 10);
        int resultingindex = 0;

        switch (firstindex)
        {
            case 1:
                resultingindex = 4;
                break;
            case 2:
                resultingindex = 5;
                break;
            case 3:
                resultingindex = 6;
                break;

            case 4:
                resultingindex = 8;
                break;
            case 5:
                resultingindex = 9;
                break;
            case 6:
                resultingindex = 10;
                break;

            case 7:
                resultingindex = 12;
                break;
            case 8:
                resultingindex = 13;
                break;
            case 9:
                resultingindex = 14;
                break;

            case 10:
                resultingindex = 16;
                break;

            default:
                Debug.Log("failed");
                break;
        }

       SceneManager.LoadScene(resultingindex);

    }
}
