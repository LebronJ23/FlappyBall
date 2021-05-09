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
	public class EndWindowController : MonoBehaviour
	{
		private EndWindow _endWindow;

		private GameStateService _gameStateService;

		[Inject]
		public void Construct(GameStateService gameStateService)
		{
			_gameStateService = gameStateService;
			_gameStateService.StateChanged += GameStateChanged;
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state == GameStateEnum.Stop)
			{
				_endWindow.Show();
			}
			else
			{
				_endWindow.Hide();
			}
		}

		private void Awake()
		{
			_endWindow = GetComponent<UIDocument>()
				.rootVisualElement
				.Q<EndWindow>()
				.Init(_gameStateService);
		}

		public void SwitchVisible()
		{
			_endWindow.SetVisible(!_endWindow.IsVisible);
		}
	}
}
