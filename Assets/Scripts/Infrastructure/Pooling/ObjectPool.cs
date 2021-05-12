using FlappyTest.Enums;
using FlappyTest.Services;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FlappyTest.Pooling
{
	public class ObjectPool<T> where T : PoolReturner
	{
		private Dictionary<string, Queue<T>> _pool = new Dictionary<string, Queue<T>>();
		private PoolReturner.Factory _factory;
		private GameStateService _gameStateService;

		[Inject]
		public void Construct(PoolReturner.Factory factory, GameStateService gameStateService)
		{
			_factory = factory;
			_gameStateService = gameStateService;

			_gameStateService.StateChanged += GameStateChanged;
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state == GameStateEnum.Stop)
			{
				foreach (var queue in _pool)
				{
					foreach (var obj in queue.Value)
					{
						GameObject.Destroy(obj);
					}
				}
				_pool.Clear();
			}
		}

		public T Get(T gameObject)
		{
			if (_pool.TryGetValue(gameObject.name, out var _objectQueue))
			{
				if (_objectQueue.Count == 0)
				{
					return CreateNew(gameObject);
				}
				else
				{
					T _pooledObj = _objectQueue.Dequeue();
					_pooledObj.gameObject.SetActive(true);
					return _pooledObj;
				}
			}
			else
			{
				return CreateNew(gameObject);
			}
		}

		private T CreateNew(T gameObject)
		{
			T newGameObject = (T)_factory.Create();
			newGameObject.gameObject.name = gameObject.name;
			return newGameObject;
		}

		public void Return(T gameObject)
		{
			if (_pool.TryGetValue(gameObject.name, out var _objectQueue))
			{
				_objectQueue.Enqueue(gameObject);
			}
			else
			{
				Queue<T> newQueue = new Queue<T>();
				newQueue.Enqueue(gameObject);
				_pool.Add(gameObject.name, newQueue);
			}

			gameObject.gameObject.SetActive(false);
		}
	}
}
