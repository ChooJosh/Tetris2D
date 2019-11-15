using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreKeeper : MonoBehaviour
{
	public Text hs1, hs2, hs3;

	private int[] highscores = { 0, 0, 0 };

	private string path = "";
	private string savesFolder = "scores";
	private string saveFileName = "highscores.txt";

	// Start is called before the first frame update
	void Start()
	{
		path = Application.dataPath + "/" + savesFolder;

		string sum = path + "/" + saveFileName;

		if (!Directory.Exists(path) || !File.Exists(sum))
		{
			return;
		}

		try
		{
			getHighScores(File.ReadAllLines(sum));

			if(hs1)
			{
				hs1.text = "First: " + highscores[0].ToString();
			}

			if (hs2)
			{
				hs2.text = "Second: " + highscores[1].ToString();
			}

			if(hs3)
			{
				hs3.text = "Third: " + highscores[2].ToString();
			}
		}
		catch(System.Exception ex)
		{
			Debug.Log(ex);
		}

	}

	// Update is called once per frame
	void Update()
    {
        
    }

	void getHighScores(string[] lines)
	{
		// f = first, s = second, t = third
		int f = 0, s = 0, t = 0;

		for(int i = 0; i< lines.Length; i++)
		{
			int current = 0;
			int.TryParse(lines[i], out current);

			if(current > f)
			{
				t = s;
				s = f;
				f = current;

				continue;
			}

			if(current > s)
			{
				t = s;
				s = current;

				continue;
			}

			if(current > t)
			{
				t = current;
			}
		}

		highscores[0] = f;
		highscores[1] = s;
		highscores[2] = t;
	}
}
