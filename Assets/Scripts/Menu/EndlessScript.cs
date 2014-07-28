using UnityEngine;
using System.Collections;

// Скрипт відповідальний за вибір ворогів у безкінечному рівні.
public class EndlessScript : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel("SelectEndless");
	}
}
