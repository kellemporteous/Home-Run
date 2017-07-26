using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraOBJ;
    public float offset;
    public float lerpspeed;
    public GameObject player;
    // Use this for initialization
    void Start ()
    {
        cameraOBJ = GameObject.FindGameObjectWithTag("MainCamera");
        

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = Vector3.MoveTowards(cameraOBJ.transform.position, player.transform.position * offset, Time.deltaTime * lerpspeed);
        move.y = cameraOBJ.transform.position.y;
        move.z = cameraOBJ.transform.position.z;
        cameraOBJ.transform.position = move;
    }
}
