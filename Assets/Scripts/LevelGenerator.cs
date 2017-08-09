using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] enemiesToSpawn;
    public Transform[] enemySpawnPoints;

    public GameObject balloonPickUp;
    public Transform[] itemSpawnArea;

    public Transform startPoint;

    private GameObject player;

    public GameObject enterPoint;
    public GameObject exitPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(player, startPoint.transform.position, Quaternion.Euler(0, 0, 0));

       

        EnemySpawn();
    }

    void EnemySpawn()
    {
        int enemySpawnPointIndex = enemySpawnPoints.Length;
        int enemyTypeIndex = Random.Range(0, enemiesToSpawn.Length);
        Instantiate(enemiesToSpawn[enemyTypeIndex], enemySpawnPoints[enemySpawnPointIndex].transform.position, Quaternion.Euler(0, 0, 0));
    }
}
