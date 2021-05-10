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

			_gameDifficultyController.DifficultyChanged += ChangeDifficulty;
			_speed = _confiiguration.StartBallSpeed;
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
