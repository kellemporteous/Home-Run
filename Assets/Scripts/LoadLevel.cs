using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Scene 1");
    }

    public void SettingsButton()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Settings");
    }

    public void HowToPlay()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Controls");
    }

    public void Credits()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Debug.Log("Bye bye");
        Application.Quit();
    }

}
