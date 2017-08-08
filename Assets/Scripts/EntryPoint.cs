using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour {


    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log(collision.gameObject.name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
