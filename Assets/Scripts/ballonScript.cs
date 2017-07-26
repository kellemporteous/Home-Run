using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonScript : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector2(transform.position.x + speed / 100, transform.position.y);
	}

    public void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == ("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().health -= 1;
            Destroy(gameObject);
        }
    }
}
