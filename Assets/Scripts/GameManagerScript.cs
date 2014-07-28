using UnityEngine;
using System.Collections;

// Скрипт відповідальний за "керування" грою.
public class GameManagerScript : MonoBehaviour {

	public static bool reload = false; 
	public static int highscore = 0;
	public static int score = 0;

	// Весь текст, який буде віображений в грі.
	public GUIText scoreText;
	public GUIText hightScoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public static bool gameOver;
	public static bool restart;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
		reload = false;
		gameOver = false;
		restart = false;
		highscore = PlayerPrefs.GetInt("High Score");
		score = 0;
		gameOverText.text = "";
		restartText.text = "";
	}

	// Update is called once per frame
	void Update ()
	{
		// Виводим на екран поточний кількість набраних очок.
		scoreText.text = "Your \nScore: \n" + score;
		if (highscore < score)
		{
			highscore = score;
		}
		hightScoreText.text = "High \nScore: \n" + highscore;

		// Збереження "High Score" в пам'яті.
		PlayerPrefs.SetInt("High Score", highscore );
		PlayerPrefs.Save();

		// Перезапуск рівня, якщо вороги дійшли до низу.
		if (reload == true)
		{
			Time.timeScale = 0;
			if (gameOver)
			{
				gameOverText.text = "Game Over!";
			}
			if (restart == true)
			{
				restartText.text = "Press 'R' for restart";
				restart = false;
			}
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
