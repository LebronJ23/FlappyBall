using System;
using FlappyTest.Controllers;
using FlappyTest.Enums;
using FlappyTest.Services;
using UnityEngine.UIElements;

namespace FlappyTest.UI
{
	public class InfoPanel : BaseElement
	{
		public new class UxmlFactory : UxmlFactory<InfoPanel, UxmlTraits> { }

		private Label _difficulty;
		private Label _timeInGame;

		private GameDifficultyController _gameDifficultyController;

		public InfoPanel Init(GameDifficultyController gameDifficultyController)
		{
			_gameDifficultyController = gameDifficultyController;

			_gameDifficultyController.DifficultyChanged += UpdateDifficulty;

			_difficulty = this.Q<Label>("Difficulty");
			_timeInGame = this.Q<Label>("TimeInGame");

			Hide();

			return this;
		}

		private void UpdateDifficulty(float level)
		{
			_difficulty.text = $"{level}";
		}

		public void UpdateTimeInGame(float time)
		{
			_timeInGame.text = $"{time.ToString("0.0")}";
		}
	}
}
