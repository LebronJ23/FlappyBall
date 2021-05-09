using System;
using FlappyTest.Enums;
using FlappyTest.Services;
using FlappyTest.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace FlappyTest.UI.Controllers
{
	[RequireComponent(typeof(UIDocument))]
	public class StartWindowController : MonoBehaviour
	{
		private StartWindow _startWindow;

		private GameStateService _gameStateService;

		[Inject]
		public void Construct(GameStateService gameStateService)
		{
			_gameStateService = gameStateService;
			_gameStateService.StateChanged += GameStateChaned;
		}

		private void GameStateChaned(GameStateEnum state)
		{
			if (state != GameStateEnum.Start)
			{
				_startWindow.Hide();
			}
		}

		private void Awake()
		{
			_startWindow = GetComponent<UIDocument>()
				.rootVisualElement
				.Q<StartWindow>()
				.Init(_gameStateService);
		}

		public void SwitchVisible()
		{
			_startWindow.SetVisible(!_startWindow.IsVisible);
		}
	}
}
