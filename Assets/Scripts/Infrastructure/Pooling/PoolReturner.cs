using FlappyTest.Controllers;
using FlappyTest.Enums;
using FlappyTest.Services;
using System;
using UnityEngine;
using Zenject;

namespace FlappyTest.Pooling
{
	public class PoolReturner : MonoBehaviour
	{
		private ObjectPool<PoolReturner> _pool;
		private GameHandler _gameHandler;
		private GameStateService _gameStateService;

		[Inject]
		public void Construct(ObjectPool<PoolReturner> pool, GameHandler gameHandler, GameStateService gameStateService)
		{
			_pool = pool;
			_gameHandler = gameHandler;
			_gameStateService = gameStateService;
			_gameStateService.StateChanged += GameStateChanged;
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state == GameStateEnum.Stop)
			{
				if (this != null)
				{
					Destroy(this.gameObject);

				}
			}
		}

		private void Update()
		{
			if (_gameStateService.IsRunning())
			{
				if (this.transform.position.x < _gameHandler.transform.position.x - 50f)
				{
					Return();
				}
			}
		}

		//private void OnDisable()
		//{
		//	Return();
		//}

		private void Return()
		{
			_pool?.Return(this);
		}

		public class Factory : PlaceholderFactory<PoolReturner>
		{

		}
	}
}
