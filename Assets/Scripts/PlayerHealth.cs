using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PlayerHealth : MonoBehaviour {

    public List<GameObject> healthImages;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public GameObject spawner;
	public float startTime;
    public GameObject player2;
	// Use this for initialization
	void Start ()
    {
        maxHealth = healthImages.Count;
        currentHealth = maxHealth;
        spawner = GameObject.FindGameObjectWithTag("spawner");
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
       

        if (currentHealth != 6)
        {
            healthImages[currentHealth].SetActive(false);
        }

        if (currentHealth == 6)
        {
            foreach (GameObject i in healthImages)
                i.SetActive(true);
        }
            

        if (currentHealth <= 0)
        {

            spawner.GetComponent<playerdist>().player = gameObject;
            spawner.GetComponent<playerdist>().spawning = true;
            currentHealth = maxHealth;
			startTime = Time.time;
            
        }
	}
}
