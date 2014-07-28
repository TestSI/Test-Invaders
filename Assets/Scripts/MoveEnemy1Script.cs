using UnityEngine;

// Скрипт для руху ворогів "Enemy_1.1"
public class MoveEnemy1Script : MonoBehaviour
{
	// Змінна, яка перевіряє в який бік руаться ворог.
	public static bool movingLeft = true;
	public static float speed = 0.5f;
	public static bool restart = false;
	public static bool shoot = false;
	
	public Vector3 direction = new Vector3(-0.1f, -2);
	
	private Vector3 movement;

	private MoveEnemy1Script moveScript;
	private WeaponEnemyScript[] weapons;

	void Awake()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponEnemyScript>();
		
		// Retrieve scripts to disable when not spawn
		//moveScript = GetComponent<WeaponEnemyScript>();
	}

	void Start () 
	{
		foreach (WeaponEnemyScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}

	// Противник робить постріл.
	public void Fire()
	{
		foreach (WeaponEnemyScript weapon in weapons)
			{
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);
					//SoundEffectsHelper.Instance.MakeEnemyShotSound();
				}
			}
	}

	void Update()
	{
		// Перевірка, чи противник може стріляти.
		if (shoot)
		{
			WeaponEnemyScript weapon = GetComponent<WeaponEnemyScript>();
			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack(false);
				SoundHelperScript.Instance.MakePlayerShotSound();
				
			}
		}
		foreach (WeaponEnemyScript weapon in weapons)
		{
			weapon.enabled = true;
		}

		Vector2 enemyPosition = transform.position;

		// Рух вліво і вниз.
		if (movingLeft == true)
		{
			if (enemyPosition.x  < -8.4f)
			{
				movingLeft = false;
			}
			
			movement = new Vector3(
				speed * -1,
				speed * 1.5f * direction.y);
		}

		// Рух вправо і вниз.
		else if (movingLeft == false)
		{
			if (enemyPosition.x > 4.8f)
			{
				movingLeft = true;
			}

			movement = new Vector3(
				speed * 1,
				speed * 1.5f * direction.y);
		}
		
		// Якщо противик дістався нижньої площини карти - робимо рестарт.
		if (enemyPosition.y < -3.4f)
		{
			GameManagerScript.reload = true;
			GameManagerScript.gameOver = true;
			GameManagerScript.restart = true;
		}

	}
	
	void FixedUpdate()
	{
		// Фізика руху.
		rigidbody2D.velocity = movement;
	}

	// Знищуєм об'єкт, який зіштохнувся з кулею.
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
