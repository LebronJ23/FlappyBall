using UnityEngine;

namespace FlappyTest.Installers
{
	[System.Serializable]
	public class Confiiguration
	{
		[Tooltip("����� �� ��������� ������ ��������� (� ��������)")]
		[Range(1f, 100f)]
		public float SecondsToNextDiffiiculty;

		[Tooltip("��������� �������� �������� ����")]
		[Range(0.01f, 5f)]
		public float StartBallSpeed;

		[Tooltip("����� ����� ������� �������")]
		[Range(0.01f, 5f)]
		public float StartSpawnTime;
	}
}
