using System;
using FlappyTest.Controllers;
using FlappyTest.Enums;
using FlappyTest.Services;
using FlappyTest.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace FlappyTest.UI.Controllers
{
	[RequireComponent(typeof(UIDocument))]
	public class InfoPanelController : MonoBehaviour
	{
		private InfoPanel _infoPanel;

		private GameStateService _gameStateService;
		private GameDifficultyController _gameDifficultyController;

		[Inject]
		public void Construct(
			GameStateService gameStateService, 
			GameDifficultyController gameDifficultyController
			)
		{
			_gameStateService = gameStateService;
			_gameDifficultyController = gameDifficultyController;

			_gameStateService.StateChanged += GameStateChanged;
		}

		private void GameStateChanged(GameStateEnum state)
		{
			if (state == GameStateEnum.Running)
			{
				_infoPanel.Show();
			}
			else
			{
				_infoPanel.Hide();
			}
		}

		private void Awake()
		{
			_infoPanel = GetComponent<UIDocument>()
				.rootVisualElement
				.Q<InfoPanel>()
				.Init(_gameDifficultyController);
		}

		private void FixedUpdate()
		{
			if (_gameStateService.IsRunning())
			{
				_infoPanel.UpdateTimeInGame(_gameDifficultyController.TimeInGame);
			}
		}
	}
}
