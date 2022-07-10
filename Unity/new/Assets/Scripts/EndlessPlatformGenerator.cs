using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform startingPlatform; //Starting platform of Endless minigame
    [SerializeField] private List<Transform> platformList; //List of platform prefabs
    [SerializeField] private Transform player;
    [SerializeField] private float PlayerDistSpawnTrigger = 50f; //Distance to trigger spawn

    Vector3 lastEndPosition;

    //Platform prefabs should contain an empty Transform "EndPosition" as a direct child
    //Next prefab is instantiated with its position (0, 0, 0) at "EndPosition"
    void Awake()
    {
        lastEndPosition = startingPlatform.Find("EndPosition").position;

        SpawnLevelPart();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, lastEndPosition) < PlayerDistSpawnTrigger)
        {
            //spawn next level part
            SpawnLevelPart();
        }
        //LevelPart triggers its Destroy(gameObject) after player passes position.x
    }

    void SpawnLevelPart()
    {
        Transform ChosenPlatform = platformList[Random.Range(0, platformList.Count)];
        Transform lastPlatformTransform = SpawnPlatform(ChosenPlatform, lastEndPosition);
        lastEndPosition = lastPlatformTransform.Find("EndPosition").position;
    }

    Transform SpawnPlatform(Transform Platform, Vector3 SpawnPoint)
    {
        Transform PlatformTransform = Instantiate(Platform, SpawnPoint, Quaternion.identity);
        return PlatformTransform;
    }
}
