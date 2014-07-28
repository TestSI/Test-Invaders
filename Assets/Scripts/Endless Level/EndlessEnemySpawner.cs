//using UnityEngine;
//using System.Collections;
//// Скритп в майбутньому буде відповідати за рандомне генерування типу ворогів в безкінечному режимі.
//public class EndlessEnemySpawner : MonoBehaviour {
//
//	int i = 0;
//	// Use this for initialization
//	void Start () {
//	
//		if (i != 0)
//		{
//			var x = transform.GetChild(0);
//			x.active = false;
//		}
//		if (i != 1)
//		{
//			var y = transform.GetChild(1);
//			y.active = false;
//		}
//		if (i != 2)
//		{
//			var z = transform.GetChild(2);
//			z.active = false;
//		}
//	}
//
//	public int WhatEnemySpawn ()
//	{
//		if (i == 0)
//		{
//			var x = transform.GetChild(0);
//			x.active = true;
//		}
//		if (i == 1)
//		{
//			var y = transform.GetChild(1);
//			y.active = true;
//		}
//		if (i == 2)
//		{
//			var z = transform.GetChild(2);
//			z.active = true;
//		}
//		return i;
//	}
//	
//	void Update () {
//		if (Input.GetButtonDown ("Fire"))
//		{
//			if(Random.value < 0.1f)
//			{
//				i = 0;
//			}
//			else if (Random.value > 0.7f)
//			{
//				i = 1;
//			}
//			else 
//			{
//				i = 2;
//			}
//		}
//	}
//}
