using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PauseMenuButtonName
{
	RESUME,
	RESTART,
	RETURN
}

public class PauseMenu : MonoBehaviour
{
	public PauseMenuButtonName pmbn = PauseMenuButtonName.RESUME;

	private Button theButton;

	public PauseListener pl;

	public GameScore gs;

    // Start is called before the first frame update
    void Start()
    {
		theButton = GetComponent<Button>();

		switch (pmbn)
		{
			case PauseMenuButtonName.RESUME:
				theButton.onClick.AddListener(onClickResume);
				break;
			case PauseMenuButtonName.RESTART:
				theButton.onClick.AddListener(onClickRestart);
				break;
			case PauseMenuButtonName.RETURN:
				theButton.onClick.AddListener(onClickReturn);
				break;
		}

		if(pl == null)
		{
			GameObject tpl = GameObject.Find("PauseListener");
			pl = tpl.GetComponent<PauseListener>();
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void onClickResume()
	{
		pl.ContinueGame();
		pl.Hide();
	}

	void onClickRestart()
	{
		pl.ContinueGame();
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

	void onClickReturn()
	{
		pl.ContinueGame();

		if(gs)
		{
			gs.saveScore();
		}

		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}
