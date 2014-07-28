using UnityEngine;
using System.Collections;

// Скрипт відповідальний за spawn противників  'Enemy_3.1' в безкінечному режимі.
public class SpawnEnemyScript3 : MonoBehaviour {

	public GameObject spawnObject;
	float spawnAreaWidth = 8; // ширина на якій буде спавнитись ворог одини від одного.
	float spawnAreaHeight = 1; // висота -//-.
	int numberOfEnemiesX = 1; // Кількість противників в рядку.
	int numberOfEnemiesY = 1; // Кількість противників в стовпці.
	public float speedIncreasePerLevel = 1.0f; // збільшення швидкості з кожним рівнем. Поки не використовується.
	public float speed = 5;
	int whoIsShooting = 0;
	public int nextLevel;
	
	void Start ()
	{
		for(int i = 0; i < numberOfEnemiesX; i++)
		{
			for(int j = 0; j < numberOfEnemiesY; j++)
			{
				Vector3 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numberOfEnemiesX);
				spawnPosition.y += j * (spawnAreaHeight/numberOfEnemiesY);
				GameObject newObject = Instantiate(spawnObject,spawnPosition,spawnObject.transform.rotation) as GameObject;
				newObject.transform.parent = transform;
			}
		}
		spawnAreaWidth = Random.Range(4,8); 
		spawnAreaHeight = 1;
		numberOfEnemiesX = Random.Range(0,5);
		numberOfEnemiesY = 1;
		MoveEnemy3Script.step = 0.1f;
		MoveEnemy2Script.speed = 2;
		MoveEnemy1Script.speed = 3.0f;
		WeaponEnemyScript.shootingRate = 4;
		InvokeRepeating("WhoIsShooting", 4.0f, 2);
	}

	int WhoIsShooting ()
	{
		whoIsShooting = Random.Range(0, transform.childCount);
		return whoIsShooting;
	}

	void Update()
	{
		// Якщо кількість противників на екрані менше 1, то спавнимо всю групу заново.
		if(transform.childCount == 4)
		{
			WeaponEnemyScript.shootingRate = 2.0f;
			MoveEnemy1Script.speed = 3.5f;
			//MoveEnemy1Script.shoot = true;
		}

		if(transform.childCount == 3)
		{
			MoveEnemy1Script.speed = 4.0f;
			MoveEnemy3Script.step = 0.2f;
			MoveEnemy2Script.speed = 3;
			WeaponEnemyScript.shootingRate = 1.5f;
		}

		if(transform.childCount == 2)
		{
			MoveEnemy1Script.speed = 5.4f;
			MoveEnemy3Script.step = 0.3f;
			MoveEnemy2Script.speed = 5;
			WeaponEnemyScript.shootingRate = 1.0f;
		}

		if(transform.childCount == 1)
		{
			MoveEnemy1Script.speed = 7.7f;
			MoveEnemy3Script.step = 0.4f;
			MoveEnemy2Script.speed = 8;
			WeaponEnemyScript.shootingRate = 0.5f;
		}

		if(transform.childCount == 0)
		{
			if (Application.loadedLevelName == "EndlessEnemy3")
			{
				Start();
			}
			else 
			{
				Application.LoadLevel(nextLevel);
			}
		}
	}
//	void FixedUpdate ()
//	{
//		var i = transform.GetChild(whoIsShooting);
//		i.GetComponent<MoveEnemy1Script>().Fire();
//	}
}
