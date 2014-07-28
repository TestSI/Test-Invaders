using UnityEngine;

// Скрипт, який полегшує виклик системи часток.
public class SpecialEffectsHelper : MonoBehaviour
{
	public static SpecialEffectsHelper Instance;
	
	public ParticleSystem smokeEffect;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Багаторазовий доступ до SpecialEffectsHelper!");
		}
		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate(smokeEffect, position);
	}

	// Створюємо і надаємо координати системі часток.
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;
		
		// Знищуємо систему часток.
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}