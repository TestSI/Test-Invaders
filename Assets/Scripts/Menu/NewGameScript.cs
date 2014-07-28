using UnityEngine;
using System.Collections;

// Скрипт для завантаження гри з головного меню.
public class NewGameScript : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel(1);
	}
	

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){ 
			Application.Quit();
		}
	}
}
