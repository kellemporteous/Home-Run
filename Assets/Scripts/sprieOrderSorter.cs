using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprieOrderSorter : MonoBehaviour {

    public Renderer thisOBj;
    public float CenterValue;
    public Transform waypoint1;
    public Transform waypoint2;
	// Use this for initialization
	void Start ()
    {
        thisOBj = gameObject.GetComponent<Renderer>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        CenterValue = (waypoint1.position.y + waypoint2.position.y) / 2;

        if (transform.position.y > CenterValue)
        {
            thisOBj.sortingLayerName = "background";
        }

        if (transform.position.y < CenterValue)
        {
            thisOBj.sortingLayerName = "foreground";
        }
    }
}
