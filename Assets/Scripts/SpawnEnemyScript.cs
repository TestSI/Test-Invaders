using UnityEngine;
using System.Collections;

// Скрипт відповідальний за spawn противників.
public class SpawnEnemyScript : MonoBehaviour {
	
	public GameObject spawnObject;
	public float spawnAreaWidth; // ширина на якій буде спавнитись ворог одини від одного.
	public float spawnAreaHeight; // висота -//-.
	public int numberOfEnemiesX; // Кількість противників в рядку.
	public int numberOfEnemiesY; // Кількість противників в стовпці.
	public float speedIncreasePerLevel = 1.0f; // збільшення швидкості з кожним рівнем. Поки не використовується.
	public float speed = 5;
	
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
	}

	void Update()
	{
		// Якщо кількість противників на екрані менше 1, то спавнимо всю групу заново.
		if(transform.childCount == 0)
		{
			speed += speedIncreasePerLevel;
			Start();
		}
	}	
}
