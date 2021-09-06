using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float startTimeBtwSpawns;
    public float enemySpeed = 3;
    float timeBtwSpawns;
    float speedCount = 0;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }

        if(timeBtwSpawns <= 0)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            PhotonNetwork.Instantiate(enemy.name, spawnPosition, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns - speedCount;
            if(speedCount < 1.8)
            {
                speedCount += 0.15f;
                Debug.Log(speedCount);
            }
        } 
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
