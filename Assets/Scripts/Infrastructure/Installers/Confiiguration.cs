using UnityEngine;

namespace FlappyTest.Installers
{
	[System.Serializable]
	public class Confiiguration
	{
		[Tooltip("����� �� ��������� ������ ��������� (� ��������)")]
		[Range(1f, 100)]
		public float SecondsToNextDiffiiculty;

		[Tooltip("��������� �������� �������� ����")]
		[Range(0.01f, 100)]
		public float StartBallSpeed;
	}
}
