using FlappyTest.Services;
using UnityEngine.UIElements;

namespace FlappyTest.UI
{
	public class StartWindow : BaseElement
	{
		public new class UxmlFactory : UxmlFactory<StartWindow, UxmlTraits> { }

		private Label _testName;
		private Button _startGameBtn;
		private GameStateService _gameStateService;

		public StartWindow Init(GameStateService gameStateService)
		{
			_gameStateService = gameStateService;

			_testName = this.Q<Label>("TestName");
			_startGameBtn = this.Q<Button>("StartGameBtn");

			_startGameBtn.clicked += OnStartBtnClick;

			return this;
		}

		private void OnStartBtnClick()
		{
			//TODO: вызов старта игры
			_gameStateService.ChangeGameState(Enums.GameStateEnum.Running);
		}
	}
}
