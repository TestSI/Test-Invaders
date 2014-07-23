using UnityEngine;

// Скрипт для запуску пуль.
public class WeaponScript : MonoBehaviour
{
	// Перетягуємо gameObject який відповідає за пулю в Unity editor. 
	public Transform shotPrefab;
	
	// Час між пострілами.
	public float shootingRate = 0.5f;
	public Vector3 newPos;
	
	private float shootCooldown;

	// Час між пострілами.
	void Start()
	{
		shootCooldown = 0.5f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Створюємо новий постріл.
			var shotTransform = Instantiate(shotPrefab) as Transform;
			
			// Присвоюємо позиції пулі, яка з'являться при пострілі.
			newPos = transform.position;
			newPos.x = newPos.x + 0f;
			newPos.y = newPos.y + 0.4f;
			shotTransform.position = newPos;
			
			// Стріляємо вгору.
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.up;
			}
		}
	}
	
	// Перевірка, чи зброя готова стріляти.
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}