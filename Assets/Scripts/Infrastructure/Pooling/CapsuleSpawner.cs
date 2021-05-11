using FlappyTest.Controllers;
using Zenject;

namespace FlappyTest.Pooling
{
	public class CapsuleSpawner : Spawner
	{
		private GameHandler _gameHandler;

		[Inject]
		public void Construct(GameHandler gameHandler)
		{
			_gameHandler = gameHandler;
		}
	}
}
