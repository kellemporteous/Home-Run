using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public List<GameObject> healthImages;
    public int maxHealth;
    public int currentHealth;
    public int damage;


	// Use this for initialization
	void Start () {
        maxHealth = healthImages.Count;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
