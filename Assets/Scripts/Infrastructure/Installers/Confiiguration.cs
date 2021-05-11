using UnityEngine;

namespace FlappyTest.Installers
{
	[System.Serializable]
	public class Confiiguration
	{
		[Tooltip("Время до изменения уровня сложности (в секундах)")]
		[Range(1f, 100f)]
		public float SecondsToNextDiffiiculty;

		[Tooltip("Начальная скорость движения шара")]
		[Range(0.01f, 5f)]
		public float StartBallSpeed;

		[Tooltip("Время между спавном преград")]
		[Range(0.01f, 5f)]
		public float StartSpawnTime;
	}
}
