using UnityEngine;
using System.Collections;

// Серипт для виходу в 4 рівні.
public class Exit : MonoBehaviour {

	void Update () {
			if (Input.GetKeyDown(KeyCode.Escape)) 
				Application.Quit();
			
	}
}
