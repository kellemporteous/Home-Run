using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public bool top;
    public GameObject jumpcube;
    public float jump_Y;
    public AudioSource headjump;

    // Use this for initialization
    void Start ()
    {
        health = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }
        if (top == true)
        {
            Debug.Log("true");
            health = health - 1;
            headjump.Play();
            top = false;
           
        }
       
	}


    public void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == ("Player") && other.gameObject.transform.position.y >= transform.position.y + 1)
        {
            if (other.gameObject.GetComponent<playerInput>().goingDown)
            {
                top = true;
            }
            if (jumpcube.transform.position.y >= transform.position.y + jump_Y)
            {
                top = true;
            }
        }
    }

}
