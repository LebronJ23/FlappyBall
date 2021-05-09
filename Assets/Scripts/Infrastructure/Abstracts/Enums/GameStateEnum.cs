using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace FlappyTest.Enums
{
	public enum GameStateEnum
	{
		[Description("Запуск игры")]
		Start,

		[Description("Игра запущена")]
		Running,

		[Description("Конец игры")]
		Stop,

		[Description("Перезапуск игры")]
		Restart
	}
}
