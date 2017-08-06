using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonScript : MonoBehaviour {

    public float speed;
    public string direction;
    public bool left;
    public GameObject player;
   
	// Use this for initialization
	void Start ()
    {
       
		left = player.GetComponent<SpriteRenderer>().flipX;
        if (left)
        {
           
        }
        else
        {
            direction = "+";
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (left)
        {
            transform.position = new Vector2(transform.position.x - speed / 100, transform.position.y);
        }

        if (!left)
        {
            transform.position = new Vector2(transform.position.x + speed / 100, transform.position.y);
        }
    }
       

    public void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == ("Enemy") )
        {
            
            other.gameObject.GetComponent<BaseEnemy>().health -= 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == ("Enemy") )
        {
            other.gameObject.GetComponent<BaseEnemy>().health -= 1;
            Destroy(gameObject);
        }

    }
}
