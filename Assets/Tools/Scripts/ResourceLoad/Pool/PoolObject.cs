using InitializeSystem;
using UnityEngine;

namespace ResourcesLoadSystem
{
	public class PoolObject : MonoBehaviour, IInitialize<PoolManager, Component, string>
	{
		private PoolManager _poolManager;
		private Component _component;
		private string _resourcePath;

		/*private void DisableAllObjectToSceneSubscription()
		{
			gameObject.SetActive(false);
		}*/

		public void Initialize(PoolManager poolManager, Component component, string resourcePath)
		{
			_poolManager = poolManager;
			_resourcePath = resourcePath;
			_component = component;
		}

		private void OnDisable()
		{
			_poolManager.ReturnInPool(_component, _resourcePath);
		}
	}
}