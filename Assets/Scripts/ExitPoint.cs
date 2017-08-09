using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour {


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "FinalLevel")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log(collision.gameObject.name);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
