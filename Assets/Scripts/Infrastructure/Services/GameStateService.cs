using FlappyTest.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FlappyTest.Services
{
	public class GameStateService : IInitializable
	{
		private GameStateEnum _gameState;
		public GameStateEnum GameState
		{
			get
			{
				return _gameState;
			}
		}

		public event Action<GameStateEnum> StateChanged;

		public void Initialize()
		{
			ChangeGameState(GameStateEnum.Start);
		}

		public void ChangeGameState(GameStateEnum gameState)
		{
			_gameState = gameState;
			StateChanged?.Invoke(_gameState);
		}

		public bool IsRunning()
		{
			return _gameState == GameStateEnum.Running;
		}
	}
}
