using UnityEngine;

// Скрипт для руху ворогів "Enemy_1.1"
public class MoveEnemy2Script : MonoBehaviour
{
	public static bool movingLeft = true; // Змінна, яка перевіряє в який бік руаться ворог.
	public static bool movingUp = false;
	public static float speed = 2;
	public static bool restart = false;
	private float nextActionTime = 3.0f;
	private float period = 5f;
	float upBorder = 6;	// Площини в яких рухається ворог.
	float downBorder = 2;
	
	public Vector3 direction = new Vector3(-1, 0);
	
	private Vector3 movement;

	void Start ()
	{
		InvokeRepeating("Borders", 1, 4);
	}
	
	void Update()
	{
		Vector2 enemyPosition = transform.position;

		// Рух вліво і вниз.
		if (movingLeft == true && movingUp == false)
			{
			if (enemyPosition.x  < -8.4f)
			{
				movingLeft = false;
			}
			if (enemyPosition.y  < downBorder)
			{
				movingUp = true;
			}

				movement = new Vector3(
					-1 * speed,
					-1 * speed);
			}

		// Рух вправо і вниз.
		else if (movingLeft == true && movingUp == true)
		{
			if (enemyPosition.x  < -8.4f)
			{
				movingLeft = false;
			}
			if (enemyPosition.y  > upBorder)
			{
				movingUp = false;
			}
			
			movement = new Vector3(
				-1 * speed,
				speed);
		}

		// Рух вліво і вгору.
		else if (movingLeft == false && movingUp == false)
		{
			if (enemyPosition.x  > 4.8f)
			{
				movingLeft = true;
			}
			if (enemyPosition.y  < downBorder)
			{
				movingUp = true;
			}
			
			movement = new Vector3(
				speed,
				-1 * speed);
		}

		// Рух вліво і вниз.
		else if (movingLeft == false && movingUp == true)
		{
			if (enemyPosition.x  > 4.8f)
			{
				movingLeft = true;
			}
			if (enemyPosition.y  > upBorder)
			{
				movingUp = false;
			}
			
			movement = new Vector3(
				speed,
				speed);
		}

		// Якщо противик дістався нижньої площини карти - робимо рестарт.
		if (enemyPosition.y < -3.4f)
		{
			GameManagerScript.reload = true;
			GameManagerScript.gameOver = true;
			GameManagerScript.restart = true;
		}
	}

	void Borders ()
	{
		downBorder = downBorder - 0.7f;
		upBorder = upBorder - 0.7f;
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
			//Debug.Log ("kill by enemy");
			Destroy(col.gameObject);
			SoundHelperScript.Instance.MakeExplosionSound();
			SpecialEffectsHelper.Instance.Explosion(transform.position);
		}
	}
}
