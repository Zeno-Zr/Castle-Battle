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

            int index = Random.Range(3, 12);
            SceneManager.LoadScene(index);

        }
        else
        {
            Debug.Log("next scene");
            FindObjectOfType<IsEndless>().IsEndlessMode = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
