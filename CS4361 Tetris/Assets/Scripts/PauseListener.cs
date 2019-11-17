using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
	public GameObject theMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(theMenu == null)
		{
			GameObject theMenu = GameObject.Find("pauseMenu");
		}

		theMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(theMenu.activeSelf)
			{
				theMenu.SetActive(false);
				ContinueGame();
			}
			else
			{
				theMenu.SetActive(true);
				PauseGame();
			}
		}
    }

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ContinueGame()
	{
		Time.timeScale = 1;
	}

	public void Hide()
	{
		theMenu.SetActive(false);
	}
}
