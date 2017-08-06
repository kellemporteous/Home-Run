using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMng : MonoBehaviour {
    public AudioSource []sounds;
    public bool iswalking;
    public bool notrunning;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        notrunning = gameObject.GetComponent<playerInput>().notrunning;
        if (iswalking && !sounds [0].isPlaying )
        {
            sounds[0].Play();
        }
        if (!notrunning)
        {
            sounds[0].pitch = 1.2f;
        }
        else
        {
            sounds[0].pitch = 0.9f;
        }
	}
}
