using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {

    //necessary varibles go here
    public GameObject attachObject;


    private float leftConstraint = Screen.width;
    private float rightConstraint = Screen.width;
    private float bottomConstraint = Screen.height;
    private float topConstraint = Screen.height;
    public float buffer;
    public float distZ;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        distZ = Mathf.Abs(cam.transform.position.z + transform.position.z);


    }
    // Use this for initialization
    void Start()
    {
        // this is so that the player is attached to the correct gameobject
        attachObject = this.gameObject;

    }


    // Update is called once per frame
    void Update()
    {

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, distZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, distZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distZ)).y;

        if (attachObject.transform.position.x < leftConstraint - buffer)
        {
            attachObject.transform.position = new Vector3(leftConstraint + buffer, attachObject.transform.position.y, distZ);
        }

        if (attachObject.transform.position.x > rightConstraint + buffer)
        {
            attachObject.transform.position = new Vector3(rightConstraint - buffer, attachObject.transform.position.y, distZ);
        }

        if (attachObject.transform.position.y >= topConstraint + buffer)
        {
            attachObject.transform.position = new Vector3(attachObject.transform.position.x, topConstraint - buffer, distZ);
        }

        if (attachObject.transform.position.y <= bottomConstraint - buffer)
        {
            attachObject.transform.position = new Vector3(attachObject.transform.position.x, bottomConstraint - buffer, distZ);
        }
    }
}
