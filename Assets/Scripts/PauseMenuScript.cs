using UnityEngine;
using System.Collections;

// Скрипт відповідальний за паузу у грі при натисканні клавіші 'Escape'.
public class PauseMenuScript : MonoBehaviour 
{
	private Rect windowRect;
	private bool paused = false , waited = true;
	
	private void Start()
	{
		windowRect = new Rect(Screen.width / 2 - 280, Screen.height / 2 - 100, 400, 100);
	}

	// Точніше зчитуваня нажаття клавіші. Тобто, немає багаторазового зчитування
	private void waiting()
	{
		waited = true;
	}
	
	private void Update()
	{
		// Робимо паузу.
		if (waited)
			if (Input.GetKey(KeyCode.Escape))
		{
			if (paused)
			{
				paused = false;
			}
			else
			{
				paused = true;
			}
			
			waited = false;
			Invoke("waiting",0.3f);
		}

		if (paused)
		{
			Time.timeScale = 0;
		}
		
}

	// Малюєм спливаюче вікно.
	private void OnGUI()
	{
		if (paused)
			windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu");
	}

	// Кнопки при паузі.
	private void windowFunc(int id)
	{
		if (GUILayout.Button("Resume"))
		{
			paused = false;
			Time.timeScale = 1;
		}

		if (GUILayout.Button("Main menu"))
		{
			Application.LoadLevel (0);
		}

		if (GUILayout.Button("Quit"))
		{
			Application.Quit();
		}
	}
}