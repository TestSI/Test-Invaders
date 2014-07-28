using UnityEngine;
using System.Collections;

// Скрипт, який полегшує контроль за звуками в грі.
public class SoundHelperScript : MonoBehaviour
	{
		public static SoundHelperScript Instance;
		
		public AudioClip explosionSound;
		public AudioClip playerShotSound;
		public AudioClip enemyShotSound;
		
		void Awake()
		{
			if (Instance != null)
			{
				Debug.LogError("Багаторазовий доступ до SoundEffectsHelper!");
			}
			Instance = this;
		}
		
		// Звук вибуху.
		public void MakeExplosionSound()
		{
			MakeSound(explosionSound);
		}
		
		// Звук пострілу гравця.
		public void MakePlayerShotSound()
		{
			MakeSound(playerShotSound);
		}
		
		// Звук пострілу ворога.
		public void MakeEnemyShotSound()
		{
			MakeSound(enemyShotSound);
		}
		
		private void MakeSound(AudioClip originalClip)
		{
			AudioSource.PlayClipAtPoint(originalClip, transform.position);
		}
	}