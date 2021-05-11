using System;
using FlappyTest.Enums;
using FlappyTest.Installers;
using FlappyTest.Services;
using UnityEngine;
using Zenject;

namespace FlappyTest.Controllers
{
	public class BallController : MonoBehaviour
	{
		private Vector3 _defaultMoving = Vector3.right;
		private Vector3 _additiveMoving = Vector3.down;

		private GameStateService _gameStateService;
		private GameDifficultyController _gameDifficultyController;
		private Confiiguration _confiiguration;
		private GameHandler _gameHandler;

		private float _speed = 0.01f;

		public float _speedKoef { get; private set; }

		[Inject]
		private void Construct(
			GameStateService gameStateService,
			GameDifficultyController gameDifficultyController,
			Confiiguration confiiguration,
			GameHandler gameHandler
			)
		{
			_gameStateService = gameStateService;
			_gameDifficultyController = gameDifficultyController;
			_confiiguration = confiiguration;
			_gameHandler = gameHandler;

			_gameStateService.StateChanged += GameStateCanged;
			_gameDifficultyController.DifficultyChanged += ChangeDifficulty;
			_speed = _confiiguration.StartBallSpeed;
			transform.position = _gameHandler._startPosition;
		}

		private void GameStateCanged(GameStateEnum state)
		{
			if (state == GameStateEnum.Restart)
			{
				RestartGame();
			}
		}

		private void ChangeDifficulty(float difficulty)
		{
			_speedKoef = difficulty;
		}

		private void FixedUpdate()
		{
			if (_gameStateService.IsRunning())
			{
				ValidateMove();
			}
		}

		private void ValidateMove()
		{
			transform.position += _speed * _speedKoef * (_defaultMoving + _additiveMoving);
			_gameHandler.transform.position += _speed * _speedKoef * _defaultMoving;
		}

		private void RestartGame()
		{
			transform.position = _gameHandler._startPosition;
			_additiveMoving = Vector3.down;
		}

		public void ChangeAdditionalDirection(bool isDown)
		{
			_additiveMoving = isDown ? Vector3.up : Vector3.down;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_gameStateService.ChangeGameState(Enums.GameStateEnum.Stop);
		}
	}
}
