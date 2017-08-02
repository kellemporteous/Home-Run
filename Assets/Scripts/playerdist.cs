using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdist : MonoBehaviour {
    public float distancebetween;
   public GameObject player;
   public GameObject player2;
    public GameObject player1prefab;
    public GameObject player2prefab;
    public bool spawning;
    public GameObject spawnpoint;
    // Use this for initialization
    void Start ()
    {
        player1prefab = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= player2.transform.position.x)
        {
            distancebetween = Vector3.Distance(player.transform.position, player2.transform.position);

        }
        if (player2.transform.position.x < player.transform.position.x)
        {
            distancebetween = Vector3.Distance(player2.transform.position, player.transform.position);
        }
        gameObject.transform.position = new Vector3(distancebetween - (distancebetween / 2), transform.position.y);



        if (spawning)
        {
            player.transform.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y);
            spawning = false;
        }
    }
}
