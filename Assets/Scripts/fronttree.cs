using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fronttree : MonoBehaviour {

    public bool isbehind;
    public GameObject player1;
    public GameObject player2;
    public float distance;
    public Color full;
    public Color half;
    // Use this for initialization
    void Start()
    {
        half = gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .3f);
        full = gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.transform.position.x >= transform.position.x - distance && player1.transform.position.x <= transform.position.x + distance)
        {
            isbehind = true;
        }
        else
        {
            isbehind = false;
        }



        if (isbehind)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(half, full,1000 * Time.smoothDeltaTime / 100);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(full,half,1000 * Time.smoothDeltaTime / 100);
        }

    }
}
