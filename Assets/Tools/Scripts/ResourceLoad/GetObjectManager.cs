using ActionSystem;
using InitializeSystem;
using ToolsSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ResourcesLoadSystem
{
	public class GetObjectManager
	{
		public GetObjectManager(ResourceLoadManager resourceLoadManager, PoolManager poolManager, MonoBehaviourManager monoBehaviourManager)
		{
			_resourceLoadManager = resourceLoadManager;
			_poolManager = poolManager;
			_monoBehaviourManager = monoBehaviourManager;
		}

		private ResourceLoadManager _resourceLoadManager;
		private PoolManager _poolManager;
		private MonoBehaviourManager _monoBehaviourManager;
		
		public TObject GetInfoObject<TObject>(string resourcesPath) where TObject : Object
		{
			return _resourceLoadManager.LoadObject<TObject>(resourcesPath);
		}
		public TComponent GetInfoComponent<TComponent>(string resourcesPath) where TComponent : Component
        {
        	return _resourceLoadManager.LoadComponent<TComponent>(resourcesPath);
        }
		
		public TComponent GetObject<TComponent>(string resourcesPath) where TComponent : Component
        {
        	return CheckForAvailabilityAndCreateIfMissing<TComponent>(resourcesPath);;
        }
		public TComponent GetObject<TComponent>(string resourcesPath, Vector3 position, Quaternion rotation) where TComponent : Component
        {
	        var component = CheckForAvailabilityAndCreateIfMissing<TComponent>(resourcesPath);
	        PreparationGameObjectBeforeUsing(component.gameObject, position, rotation);
        	return component;
        }
		public TComponent GetObject<TComponent>(string resourcesPath, Vector3 position, Quaternion rotation, Transform parent) where TComponent : Component
        {
	        var component = CheckForAvailabilityAndCreateIfMissing<TComponent>(resourcesPath);
	        PreparationGameObjectBeforeUsing(component.gameObject, position, rotation, parent);
	        return component;
        }
		public TComponent GetObject<TComponent>(string resourcesPath, Vector3 position, Quaternion rotation, float timeout) where TComponent : Component
        {
	        var component = CheckForAvailabilityAndCreateIfMissing<TComponent>(resourcesPath);
	        UpdateTimeout(component.gameObject, timeout);
	        PreparationGameObjectBeforeUsing(component.gameObject, position, rotation);
	        return component;
        }
		public TComponent GetObject<TComponent>(string resourcesPath, Vector3 position, Quaternion rotation, Transform parent, float timeout) where TComponent : Component
        {
	        var component = CheckForAvailabilityAndCreateIfMissing<TComponent>(resourcesPath);
	        UpdateTimeout(component.gameObject, timeout);
	        PreparationGameObjectBeforeUsing(component.gameObject, position, rotation, parent);
	        return component;
        }
		
		private TComponent CheckForAvailabilityAndCreateIfMissing<TComponent>(string resourcesPath) where TComponent : Component
        {
        	var component = _poolManager.UsingPool<TComponent>(resourcesPath);
        	if (!ReferenceEquals(component, null)) return component;
            
            component = _monoBehaviourManager.InstantiateGameObjectByComponent(GetInfoComponent<TComponent>(resourcesPath));
            component.gameObject.AddComponent<PoolObject, PoolManager, Component, string>(_poolManager, component, resourcesPath);
            return component;
        }
 		private void PreparationGameObjectBeforeUsing(GameObject go , Vector3 position,
			Quaternion rotation, Transform parent = null)
		{
			Transform trans = go.transform;
			trans.position = position;
			trans.rotation = rotation;
			if (!ReferenceEquals(parent, null))
				trans.SetParent(parent);
			go.SetActive(true);
		}
        private void UpdateTimeout(GameObject go, float timeout)
        {
	        Timeout timeoutComponent = go.GetComponent<Timeout>() ?? go.AddComponent<Timeout>();
	        timeoutComponent.Assign(timeout);
        }
	}
}