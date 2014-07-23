using UnityEngine;
using System.Collections;

// Скрипт відповідальний за "керування" грою.
public class GameManagerScript : MonoBehaviour {

	public static bool reload = false;
	public static int highscore = 0;
	public static int score = 0;

	// Use this for initialization
	void Start () 
	{
		highscore = PlayerPrefs.GetInt("High Score");
		score = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		if (highscore < score)
		{
			highscore = score;
		}

		// Збереження "High Score" в пам'яті.
		PlayerPrefs.SetInt("High Score", highscore );
		PlayerPrefs.Save();

		// Перезапуск рівня, якщо вороги дійшли до низу.
		if (reload == true)
		{
			reload = false;
			StartCoroutine(ShowMessage("Abc", 2));
			Application.LoadLevel(0);
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			StartCoroutine(ShowMessage("Abc", 2));
		}
	}

	IEnumerator ShowMessage (string message, float delay) {
		guiText.text = "af";
		guiText.enabled = true;
		yield return new WaitForSeconds(delay);
		guiText.enabled = false;
	}

	void OnGUI ()
	{
		// Відображення на екрані "Score" і "High Score".
		GUI.Label (new Rect(1150, 10, 100, 30), "High Score: " + (int)(highscore)); 
		GUI.Label (new Rect(1150, 30, 100, 30), "Score: " + (int)(score)); 
	}

}
