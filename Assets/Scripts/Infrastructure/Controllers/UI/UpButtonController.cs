using System;
using FlappyTest.Controllers;
using FlappyTest.Enums;
using FlappyTest.Services;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace FlappyTest.UI.Controllers
{
	[RequireComponent(typeof(UIDocument))]
	public class UpButtonController : MonoBehaviour
	{
		private UpButton _upButton;

		private BallController _ballController;

		private GameStateService _gameStateService;

		[Inject]
		public void Construct(BallController ballController, GameStateService gameStateService)
		{
			_ballController = ballController;
			_gameStateService = gameStateService;

			_gameStateService.StateChanged += ChangedGameState;
		}

		private void ChangedGameState(GameStateEnum state)
		{
			switch (state)
			{
				case GameStateEnum.Running:
					_upButton.Show();
					break;
				case GameStateEnum.Restart:
					_upButton.Reset();
					break;
				case GameStateEnum.Stop:
					_upButton.Hide();
					break;
			}

			//if (_gameStateService.IsRunning())
			//{
			//	_upButton.Show();
			//}
			//else
			//{
			//	_upButton.Hide();
			//}
		}

		private void Awake()
		{
			_upButton = GetComponent<UIDocument>()
				.rootVisualElement
				.Q<UpButton>()
				.Init(_ballController);
		}


	}
}
