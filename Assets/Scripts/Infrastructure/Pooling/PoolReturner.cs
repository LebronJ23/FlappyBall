using FlappyTest.Controllers;
using FlappyTest.Services;
using UnityEngine;
using Zenject;

namespace FlappyTest.Pooling
{
	public class PoolReturner : MonoBehaviour
	{
		private ObjectPool _pool;
		private GameHandler _gameHandler;
		private GameStateService _gameStateService;

		[Inject]
		public void Construct(ObjectPool pool, GameHandler gameHandler, GameStateService gameStateService)
		{
			_pool = pool;
			_gameHandler = gameHandler;
			_gameStateService = gameStateService;
		}

		private void Update()
		{
			if (_gameStateService.IsRunning())
			{
				if (this.transform.position.x < _gameHandler.transform.position.x)
				{
					Destroy(this);
				}
			}
		}

		private void OnDisable()
		{
			Return();
		}

		private void Return()
		{
			_pool?.Return(gameObject);
		}
	}
}
