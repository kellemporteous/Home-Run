using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprieOrderSorter : MonoBehaviour {

    public Renderer thisOBj;
   // public float CenterValue;
    public Transform waypoint1;
    public Transform waypoint2;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {   if (transform.position.y <=-1)
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}
