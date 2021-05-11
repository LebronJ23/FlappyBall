using System;
using FlappyTest.Enums;
using FlappyTest.Services;
using UnityEngine;
using Zenject;

namespace FlappyTest.Controllers
{
	public class GameHandler : MonoBehaviour
	{
		public Vector3 _startPosition { get; private set; }

		private GameStateService _gameStateService;

		[Inject]
		public void Construct(GameStateService gameStateService)
		{
			_startPosition = transform.position;
			_gameStateService = gameStateService;
			_gameStateService.StateChanged += GameStateChanged;
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state == GameStateEnum.Restart)
			{
				transform.position = _startPosition;
			}
		}
	}
}
