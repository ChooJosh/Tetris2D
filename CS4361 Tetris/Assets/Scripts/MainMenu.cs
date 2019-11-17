using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MainMenuButtonName
{
	START,
	HIGHSCORES,
	QUIT
}

public class MainMenu : MonoBehaviour
{
	public MainMenuButtonName mbn = MainMenuButtonName.START;

	private Button theButton;

	public GameObject hscanvas;

	// Start is called before the first frame update
	void Start()
    {
		theButton = GetComponent<Button>();

		if(hscanvas)
		{
			hscanvas.SetActive(false);
		}

		switch(mbn)
		{
			case MainMenuButtonName.START:
				theButton.onClick.AddListener(onClickStart);
				break;
			case MainMenuButtonName.HIGHSCORES:
				theButton.onClick.AddListener(onClickHighScore);
				break;
			case MainMenuButtonName.QUIT:
				theButton.onClick.AddListener(onClickQuit);
				break;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void onClickStart()
	{
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

	void onClickHighScore()
	{
		if(hscanvas != null)
		{
			hscanvas.SetActive(true);
		}
	}

	void onClickQuit()
	{
		Application.Quit();
	}
}