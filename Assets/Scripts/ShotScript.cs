using UnityEngine;

// Скрипт відповідальний за зниження пулею ворогів і головного героя.
public class ShotScript : MonoBehaviour
{	
	// На майбутнє. Damage отриманий від пулі.
	public int damage = 1;
	// На майбутнє. Пуля ворожа чи своя?
	public bool isEnemyShot = false;
	public float speed = 6;
	public Vector3 direction = new Vector3(0, 1);
	private Vector3 movement;

	
	void Start()
	{
		// Зниження пулі після 2 секунд.
		Destroy(gameObject, 2f); // 2sec

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		// Зниження пулі, якщо вона досягла ворга.
		if(col.gameObject.tag == "Enemy")
		{
			Destroy(col.gameObject);
			GameManagerScript.score += 30;
		}
	}

	// Рух пулі.
	void Update()
	{
		movement = new Vector3(
			speed * 0,
			5 * 1);
	}
	
	void FixedUpdate()
	{
		// Фізика руху
		rigidbody2D.velocity = movement;
	}
}