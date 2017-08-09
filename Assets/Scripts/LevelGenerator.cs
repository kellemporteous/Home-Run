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
        EnemySpawn();
        if (!player.activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Instantiate(player, startPoint.transform.position, Quaternion.Euler(0, 0, 0));

       

      
    }

    void EnemySpawn()
    {
       

        foreach (Transform spawnPoint in enemySpawnPoints)
        {
            int enemyTypeIndex = Random.Range(0, enemiesToSpawn.Length);
            Instantiate(enemiesToSpawn[enemyTypeIndex], spawnPoint.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
