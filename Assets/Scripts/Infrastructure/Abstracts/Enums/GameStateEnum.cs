using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace FlappyTest.Enums
{
	public enum GameStateEnum
	{
		[Description("������ ����")]
		Start,

		[Description("���� ��������")]
		Running,

		[Description("����� ����")]
		Stop,

		[Description("���������� ����")]
		Restart
	}
}
