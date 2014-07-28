using UnityEngine;

// Скрипт для руху ворогів "Enemy_1.1"
public class MoveEnemy3Script : MonoBehaviour
{
	// Змінна, яка перевіряє в який бік руаться ворог.
	public static bool movingLeft = true;
	public static bool movingUp = false;
	public static float speed = 0.5f;
	public static float step = 0.1f;
	float speedY = 5;
	public static bool restart = false;
	float nextActionTime = 2.0f;
	float period = 1f;
	
	public Vector3 direction = new Vector3(-1, 0);
	
	private Vector3 movement;

	void Start ()
	{
		InvokeRepeating("EverySecond", 0.3f, 1);
	}

	void Update()
	{
		Vector2 enemyPosition = transform.position;

		movement = new Vector3 (Random.Range(-1, 1), 0, 0);
		
		// Якщо противик дістався нижньої площини карти - робимо рестарт.
		if (enemyPosition.y < -3.4f)
		{
			GameManagerScript.reload = true;
			GameManagerScript.gameOver = true;
			GameManagerScript.restart = true;
		}
	}

	// Переміщення в рандомну точку по осі x.
	float EverySecond ()
	{
		transform.position = new Vector3 (Random.Range(-8.4F, 4.8F), speedY, -1);
		speedY -= step;
		return speedY;
	}

	void FixedUpdate()
	{
		// Фізика руху.
		rigidbody2D.velocity = movement;
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Shot")
		{
			Destroy(col.gameObject);
			SoundHelperScript.Instance.MakeExplosionSound();
			SpecialEffectsHelper.Instance.Explosion(transform.position);
		}
	}
}