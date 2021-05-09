using FlappyTest.Enums;
using FlappyTest.Installers;
using FlappyTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace FlappyTest.Controllers
{
	public class GameDifficultyController : MonoBehaviour
	{
		public float TimeInGame { get; private set; }

		public event Action<float> DifficultyChanged;

		private Confiiguration _confiiguration;

		private GameStateService _gameStateService;

		private int _difficulty;

		[Inject]
		public void Construct(Confiiguration confiiguration, GameStateService gameStateService)
		{
			_confiiguration = confiiguration;
			_gameStateService = gameStateService;
			_gameStateService.StateChanged += GameStateChanged;

			Restore();
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state != GameStateEnum.Running)
			{
				Restore();
				DifficultyChanged?.Invoke(_difficulty);
			}
		}

		private void FixedUpdate()
		{
			if (_gameStateService.GameState == GameStateEnum.Running)
			{
				TimeInGame += Time.deltaTime;

				if (_confiiguration.SecondsToNextDiffiiculty * _difficulty <= TimeInGame)
				{
					DifficultyChanged?.Invoke(++_difficulty);
				}
			}
		}

		private void Restore()
		{
			TimeInGame = 0;
			_difficulty = 1;
		}

	}
}
