using FlappyTest.Services;
using UnityEngine.UIElements;

namespace FlappyTest.UI
{
	public class EndWindow : BaseElement
	{
		public new class UxmlFactory : UxmlFactory<EndWindow, UxmlTraits> { }

		private Label _testName;
		private Button _restartGameBtn;
		private GameStateService _gameStateService;

		public EndWindow Init(GameStateService gameStateService)
		{
			_gameStateService = gameStateService;

			_testName = this.Q<Label>("TestName");
			_restartGameBtn = this.Q<Button>("RetartGameBtn");

			_restartGameBtn.clicked += OnRestartBtnClick;

			Hide();

			return this;
		}

		private void OnRestartBtnClick()
		{
			//TODO: вызов пеерезапуска игры
			_gameStateService.ChangeGameState(Enums.GameStateEnum.Restart);
		}
	}
}
