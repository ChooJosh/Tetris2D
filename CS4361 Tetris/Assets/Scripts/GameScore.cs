using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class GameScore : MonoBehaviour
{
	public int score = 0;
	private string path = "";
	private string saveFileName = "highscores.txt";

	public Text display;

    // Start is called before the first frame update
    void Start()
    {
		path = Application.dataPath + "/scores";

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void saveScore()
	{
		try
		{
			string sum = path + "/" + saveFileName;

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			if (!File.Exists(sum))
			{
				File.Create(sum);
			}

			File.AppendAllText(sum, score.ToString() + "\n");
			Debug.Log("wrote to file");
		}
		catch(System.Exception ex)
		{
			Debug.Log(ex);
		}
	}

	public void addToScore(int num)
	{
		score += num;

		if(display)
		{
			display.text = score.ToString();
		}
	}
}
