using UnityEngine;

namespace FlappyTest.Installers
{
	[System.Serializable]
	public class Confiiguration
	{
		[Tooltip("¬рем€ до изменени€ уровн€ сложности (в секундах)")]
		[Range(0.001f, 100)]
		public float SecondsToNextDiffiiculty;
	}
}
