using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyTest.Pooling
{
	public class ObjectPool : MonoBehaviour
	{
		private Dictionary<string, Queue<GameObject>> _pool = new Dictionary<string, Queue<GameObject>>();

		public GameObject Get(GameObject gameObject)
		{
			if (_pool.TryGetValue(gameObject.name, out var _objectQueue))
			{
				if (_objectQueue.Count == 0)
				{
					return CreateNew(gameObject);
				}
				else
				{
					GameObject _pooledObj = _objectQueue.Dequeue();
					_pooledObj.SetActive(true);
					return _pooledObj;
				}
			}
			else
			{
				return CreateNew(gameObject);
			}
		}

		private GameObject CreateNew(GameObject gameObject)
		{
			GameObject newGameObject = Instantiate(gameObject);
			newGameObject.name = gameObject.name;
			return newGameObject;
		}

		public void Return(GameObject gameObject)
		{
			if (_pool.TryGetValue(gameObject.name, out var _objectQueue))
			{
				_objectQueue.Enqueue(gameObject);
			}
			else
			{
				Queue<GameObject> newQueue = new Queue<GameObject>();
				newQueue.Enqueue(gameObject);
				_pool.Add(gameObject.name, newQueue);
			}

			gameObject.SetActive(false);
		}
	}
}
