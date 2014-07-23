using UnityEngine;
using System.Collections;

// Скрипт для управління головним героєм (танком).
public class PlayerControlScript : MonoBehaviour {
	
	public float speed = 5;
	public static bool shoot;
	Vector2 movement;

	void start()
	{
		movement = Vector2.zero;
		shoot = false;
	}

	void Update () {

		// Рух персонажу
		if (Input.GetKey("a") || Input.GetKey ("left"))
		{
			movement = new Vector2(-1, 0);
		}
		else if (Input.GetKey("d")|| Input.GetKey ("right"))
		{
			movement = new Vector2(1,0);
		}
		else
		{
			movement = Vector2.zero;
		}

		// Стріляємо.
		if (Input.GetButtonDown ("Fire"))
		{
			shoot = true;
		}
		else if (Input.GetButtonUp ("Fire"))
		{
			shoot = false;
		}    
		if (shoot)
			{
				WeaponScript weapon = GetComponent<WeaponScript>();
				if (weapon != null && weapon.CanAttack)
				{
					weapon.Attack(false);
					//SoundEffectsHelper.Instance.MakePlayerShotSound();
				
				}
			}
	}

	void FixedUpdate () 
	{
		// Фізика руху
		rigidbody2D.velocity = new Vector2(movement.x * speed, 0);
	}
}
