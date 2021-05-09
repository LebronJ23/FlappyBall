using UnityEngine;
using Zenject;

namespace FlappyTest.Installers
{
	[CreateAssetMenu(fileName = "ConfigurationInstaller", menuName = "Configurations/Main")]
	public class ConfigurationInstaller : ScriptableObjectInstaller<ConfigurationInstaller>
	{
		public Confiiguration _config;
		public override void InstallBindings()
		{
			Container.BindInstance(_config);
		}
	}
}
