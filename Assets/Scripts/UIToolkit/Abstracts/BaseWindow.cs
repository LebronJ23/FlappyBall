using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace FlappyTest.UI
{
	public class BaseElement : VisualElement
	{
		public bool IsVisible => style.display == DisplayStyle.Flex;

		public virtual void SetVisible(bool value)
		{
			if (value)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		public virtual void Show()
		{
			style.display = DisplayStyle.Flex;
		}

		public virtual void Hide()
		{
			style.display = DisplayStyle.None;
		}
	}
}
