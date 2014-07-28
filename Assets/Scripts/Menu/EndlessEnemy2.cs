using UnityEngine;
using System.Collections;

// Скрипт відповідальний за вибір ворогів у безкінечному рівні.
public class EndlessEnemy2 : MonoBehaviour {
	
	void OnMouseDown () {
		Application.LoadLevel("EndlessEnemy2");
	}
}
