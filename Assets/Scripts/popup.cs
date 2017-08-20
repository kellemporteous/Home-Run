using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour {
    public bool pickupani;
    public GameObject player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pickupani)
        {
            player.GetComponent<playerInput>().popup = true;
        }
	}
}
