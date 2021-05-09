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
		private float _speed = 0.01f;

		public float _speedKoef { get; private set; }

		[Inject]
		private void Construct(
			GameStateService gameStateService,
			GameDifficultyController gameDifficultyController
			)
		{
			_gameStateService = gameStateService;
			_gameDifficultyController = gameDifficultyController;

			_gameDifficultyController.DifficultyChanged += ChangeDifficulty;
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
		}

		public void ChangeAdditionalDirection(bool isMouseDown)
		{
			_additiveMoving = isMouseDown ? Vector3.up : Vector3.down;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_gameStateService.ChangeGameState(Enums.GameStateEnum.Stop);
		}
	}
}
