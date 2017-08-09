using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandle : MonoBehaviour {

    public GameObject [] buttons;
    public string [] SceneName;
    public Color UnSelected;
    public int Selected;
    public bool ispressed;

	// When menu loads it is given it's designated colour
	void Start () {
        UnSelected = buttons[0].GetComponent<Image>().color;
        buttons[0].GetComponent<Image>().color = (Color.green);	
	}

    // Allows movement through menu with arrow keys
    void Update()
    {

        if (!ispressed)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("verticalP1") == -1f)
            {
                if (Selected >= 1)
                {
                    Selected -= 1;
                    ispressed = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("verticalP1") == 1f)
            {
                if (Selected < buttons.Length - 1)
                {
                    Selected += 1;
                    ispressed = true;
                }
            }
        }
        if (Input.GetAxis("verticalP1") == 0f)
        {
            ispressed = false;
        }
            if (Input.GetKeyDown(KeyCode.Space) && (Selected < buttons.Length - 1))
            {
                SceneManager.LoadScene(SceneName[Selected]);
            }
            if (Input.GetKeyDown(KeyCode.Space) && (Selected == buttons.Length - 1))
            {
                Debug.Log("Is quitting");
                QuitGame();
            }

            if (Selected == 0)
            {
                StartButton();
            }
            else
            {
                buttons[0].GetComponent<Image>().color = (UnSelected);
            }
            if (Selected == 1)
            {
                SettingsButton();
            }
            else
            {
                buttons[1].GetComponent<Image>().color = (UnSelected);
            }
            if (Selected == 2)
            {
                HowToPlay();
            }
            else
            {
                buttons[2].GetComponent<Image>().color = (UnSelected);
            }
            if (Selected == 3)
            {
                Credits();
            }
            else
            {
                buttons[3].GetComponent<Image>().color = (UnSelected);
            }
            if (Selected == 4)
            {
                QuitGame();
            }
            else
            {
                buttons[4].GetComponent<Image>().color = (UnSelected);
            }
        }
    

    public void StartButton()
    {
        buttons[0].GetComponent<Image>().color = (Color.green);
    }

    public void SettingsButton()
    {
        buttons[1].GetComponent<Image>().color = (Color.green);
    }

    public void HowToPlay()
    {
        buttons[2].GetComponent<Image>().color = (Color.green);
    }

    public void Credits()
    {
        buttons[3].GetComponent<Image>().color = (Color.green);
    }

    public void QuitGame()
    {
        buttons[4].GetComponent<Image>().color = (Color.green);
    }

}
