using System;
using FlappyTest.Controllers;
using FlappyTest.Services;
using FlappyTest.UI.Controllers;
using UnityEngine;
using Zenject;

namespace FlappyTest.Installers
{
	public class SceneInstaller : MonoInstaller
	{
		[SerializeField]
		private StartWindowController _startWindowController;

		[SerializeField]
		private EndWindowController _endWindowController;

		[SerializeField]
		private UpButtonController _upButtonController;

		[SerializeField]
		private InfoPanelController _infoPanelController;

		[SerializeField]
		private GameDifficultyController _gameDifficultyController;

		[SerializeField]
		private BallController _ballConroller;

		public override void InstallBindings()
		{
			BindObjects();
			BindServices();
		}

		private void BindServices()
		{
			Container.BindInterfacesAndSelfTo<GameStateService>().AsSingle();
		}

		private void BindObjects()
		{
			Container.Bind<GameDifficultyController>().FromComponentInNewPrefab(_gameDifficultyController).AsSingle().NonLazy();
			Container.Bind<BallController>().FromComponentInNewPrefab(_ballConroller).AsSingle().NonLazy();

			Container.BindInstance(_startWindowController).AsSingle();
			Container.BindInstance(_endWindowController).AsSingle();
			Container.BindInstance(_upButtonController).AsSingle();
			Container.BindInstance(_infoPanelController).AsSingle();
		}
	}
}
