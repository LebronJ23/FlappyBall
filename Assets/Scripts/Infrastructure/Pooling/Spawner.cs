using FlappyTest.Controllers;
using FlappyTest.Enums;
using FlappyTest.Installers;
using FlappyTest.Services;
using System;
using UnityEngine;
using Zenject;

namespace FlappyTest.Pooling
{
	public class Spawner : MonoBehaviour
	{
		private float _lastSpawnTime;
		private ObjectPool _pool;

		[SerializeField]
		private GameObject _spawnedPref;

		private float _defaultSpawnTime;

		private Confiiguration _confiiguration;
		private GameDifficultyController _gameDifficultyController;
		private GameStateService _gameStateService;

		private const float MAX_CAMERA_RANGE = 100f;

		[Inject]
		public void Construct(
			Confiiguration confiiguration,
			GameStateService gameStateService,
			GameDifficultyController gameDifficultyController,
			ObjectPool pool)
		{
			_confiiguration = confiiguration;
			_gameDifficultyController = gameDifficultyController;
			_gameStateService = gameStateService;
			_pool = pool;

			_defaultSpawnTime = _confiiguration.StartSpawnTime;
			_gameStateService.StateChanged += GameStateChanged;
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state != GameStateEnum.Running)
			{
				_lastSpawnTime = 0f;
			}
		}

		private void Update()
		{
			if (_gameStateService.IsRunning())
			{
				_lastSpawnTime += Time.deltaTime;

				if (_lastSpawnTime >= _defaultSpawnTime)
				{
					GameObject spawnObject = _pool.Get(_spawnedPref);
					spawnObject.transform.position = this.transform.position + new Vector3(0, UnityEngine.Random.Range(0, MAX_CAMERA_RANGE), 0);
					_lastSpawnTime = 0f;
				}
			}

		}
	}
}
