using UnityEngine;

// Скрипт для руху ворогів "Enemy_1.1"
public class MoveScript : MonoBehaviour
{
	// Змінна, яка перевіряє в який бік руаться ворог.
	public static bool movingLeft = true;
	public float speed = 1;
	public static bool restart = false;
	
	public Vector3 direction = new Vector3(-1, 0);
	
	private Vector3 movement;
	
	void Update()
	{
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
				0.1f * direction.y);
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
				0.1f * direction.y);
		}
		
		// Якщо противик дістався нижньої площини карти - робимо рестарт.
		if (enemyPosition.y < -3.4f)
		{
			GameManagerScript.reload = true;
		}
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
		}
	}
}
