using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraOBJ;
    public float offset;
    public float lerpspeed;
    public GameObject player;
    public GameObject player2;
    public GameObject twoplayerObj;
    public GameObject popup;
    public bool canplay;
    
    // Use this for initialization
    void Start ()
    {
        cameraOBJ = GameObject.FindGameObjectWithTag("MainCamera");
        canplay = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (player2.activeInHierarchy)
        {
            player = twoplayerObj;
        }
        Vector3 move = Vector3.MoveTowards(cameraOBJ.transform.position, player.transform.position * offset, Time.deltaTime * lerpspeed);
        move.y = cameraOBJ.transform.position.y;
        move.z = cameraOBJ.transform.position.z;
        cameraOBJ.transform.position = move;

        if (transform.position.x <= player.transform.position.x + 6 && canplay)
        {
            popup.GetComponent<Animator>().SetBool ("play",true);
            canplay = false;
        }
    }
}
