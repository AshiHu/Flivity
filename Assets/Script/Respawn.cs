using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Respawn : MonoBehaviour
{
    [Header("player information")]
    public GameObject playerPrefab;
    private GameObject newPlayer;

    [Header("Spawn Points")]
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject selectedSpawnpoint;
    private Transform transformSpawnpoint;
   
    [Header("dead zone")]
    [SerializeField] private GameObject[] deadZone;

    void Start()
    {
        int rand = Random.Range(0, 8);
        selectedSpawnpoint = spawnPoints[rand];

        transformSpawnpoint = selectedSpawnpoint.transform;
    }
    void Update()
    {
        if (this.transform.position.y <= 2f)
        {
            RespawnMethod();
            int rand = Random.Range(0, 8);
            selectedSpawnpoint = spawnPoints[rand];
        }
    }
    private void RespawnMethod()
    {
        Destroy(gameObject);
        newPlayer = Instantiate(playerPrefab, transformSpawnpoint.position, transformSpawnpoint.rotation);
    }
}
