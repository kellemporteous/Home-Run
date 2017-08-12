using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] enemiesToSpawn;
    public Transform[] enemySpawnPoints;
    public GameObject[] enemyspawnpointobjs;
    public GameObject balloonPickUp;
    public Transform[] itemSpawnArea;

    public Transform startPoint;

    private GameObject player;

    public GameObject enterPoint;
    public GameObject exitPoint;

    void Start()
    {
        EnemySpawn();
        if (!player.activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Instantiate(player, startPoint.transform.position, Quaternion.Euler(0, 0, 0));


     

    }

    void EnemySpawn()
    {
       
        enemyspawnpointobjs = GameObject.FindGameObjectsWithTag("enemySpawnPoint");
        enemySpawnPoints = new Transform[enemyspawnpointobjs.Length];
        for (int i = 0; i < enemyspawnpointobjs.Length; ++i)
            enemySpawnPoints[i] = enemyspawnpointobjs[i].transform;

        foreach (Transform spawnPoint in enemySpawnPoints)
        {
            int enemyTypeIndex = Random.Range(0, enemiesToSpawn.Length);
            Instantiate(enemiesToSpawn[enemyTypeIndex], spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
