using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject enemy;
    public Transform[] enemySpawnPoints;

    public GameObject balloonPickUp;
    public Transform[] itemSpawnArea;

    public Transform startPoint;

    

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void EnemySpawn()
    {
        Instantiate(enemy, enemySpawnPoints[].transform.position, Quaternion.Euler(0, 0, 0));
    }

}
