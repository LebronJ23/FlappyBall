using UnityEngine;

namespace FlappyTest.Installers
{
	[System.Serializable]
	public class Confiiguration
	{
		[Tooltip("¬рем€ до изменени€ уровн€ сложности (в секундах)")]
		[Range(1f, 100)]
		public float SecondsToNextDiffiiculty;

		[Tooltip("Ќачальна€ скорость движени€ шара")]
		[Range(0.01f, 100)]
		public float StartBallSpeed;
	}
}
