using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour {
    public bool pickupani;
    public GameObject player;
	public GameObject brother;
	// Use this for initialization
	void Start ()
    {
		brother = GameObject.FindGameObjectWithTag ("Brother");
	}
	
	// Update is called once per frame
	void Update ()
    {
		float diff = (brother.transform.position - player.transform.position).magnitude;

        if (pickupani)
        {
			if(diff < 3)
			{player.GetComponent<playerInput>().popup = true;
            }

        }
	}
}
