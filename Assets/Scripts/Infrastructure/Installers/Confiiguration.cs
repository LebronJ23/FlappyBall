using UnityEngine;

namespace FlappyTest.Installers
{
	[System.Serializable]
	public class Confiiguration
	{
		[Tooltip("����� �� ��������� ������ ��������� (� ��������)")]
		[Range(0.001f, 100)]
		public float SecondsToNextDiffiiculty;
	}
}
