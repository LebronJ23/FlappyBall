using System.Collections.Generic;
using Zenject;

namespace FlappyTest.Pooling
{
	public class ObjectPool<T> where T : PoolReturner
	{
		private Dictionary<string, Queue<T>> _pool = new Dictionary<string, Queue<T>>();
		private PoolReturner.Factory _factory;

		[Inject]
		public void Construct(PoolReturner.Factory factory)
		{
			_factory = factory;
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
