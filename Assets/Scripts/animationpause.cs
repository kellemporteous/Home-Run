using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationpause : MonoBehaviour {
    public GameObject[] players;
    public bool anipopup;
	// Use this for initialization
	void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        {
            if (anipopup)
            {
                foreach (GameObject i in players)
                {
                    i.GetComponent<playerInput>().popup = true;
                }
            }
        }
	}
}
