using System;
using FlappyTest.Controllers;
using UnityEngine.UIElements;

namespace FlappyTest.UI
{
	public class UpButton : BaseElement
	{
		public new class UxmlFactory : UxmlFactory<UpButton, UxmlTraits> { }

		private Button _upButton;

		private BallController _ballController;

		private bool _isUp = false;

		public UpButton Init(BallController ballController)
		{
			_ballController = ballController;

			_upButton = this.Q<Button>("UpBtn");
			_upButton.clicked += ChangeDirection;
			//_upButton.RegisterCallback<MouseDownEvent>(GoDown);
			//_upButton.RegisterCallback<MouseUpEvent>(GoUp);

			Hide();

			return this;
		}

		private void ChangeDirection()
		{
			_isUp = !_isUp;
			_upButton.text = _isUp ? "Down" : "Up";
			_ballController.ChangeAdditionalDirection(_isUp);
		}

		public void Reset()
		{
			_isUp = false;
			_upButton.text = "Up";
		}

		//private void GoDown(MouseDownEvent evt)
		//{
		//	_ballController.ChangeAdditionalDirection(true);
		//}

		//private void GoUp(MouseUpEvent evt)
		//{
		//	_ballController.ChangeAdditionalDirection(false);
		//}
	}
}
