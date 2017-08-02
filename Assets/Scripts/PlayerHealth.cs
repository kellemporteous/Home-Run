﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public List<GameObject> healthImages;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public GameObject spawner;
	public float startTime;

	// Use this for initialization
	void Start () {
        maxHealth = healthImages.Count;
        currentHealth = maxHealth;
        spawner = GameObject.FindGameObjectWithTag("spawner");
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
        {
			Analytics.CustomEvent("gameOver", new Dictionary<string, object>
				{
					{ "playTime", Time.time-startTime }
					//{ "coins", totalCoins },
					//{ "activeWeapon", weaponID }
				});
            spawner.GetComponent<playerdist>().spawning = true;
            currentHealth = maxHealth;
			startTime = Time.time;
        }
	}
}
