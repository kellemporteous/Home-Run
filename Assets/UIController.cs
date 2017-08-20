using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public bool isPopUp;

	// Use this for initialization
	void Start ()
    {
        isPopUp = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.E) && isPopUp == false)
        {
            isPopUp = true;
        }

        if (Input.GetKey(KeyCode.E) && isPopUp == true)
        {
            isPopUp = false;
        }

        if (isPopUp == true)
        {
            Time.timeScale = 0;
        }

        else if (isPopUp == false)
        {
            Time.timeScale = 1;
        }
	}
}