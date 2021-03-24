using UnityEngine;

namespace ResourcesLoadSystem
{
	public class ResourceLoadManager
	{
		public TObject LoadObject<TObject>(string resourcePath) where TObject : Object
        {
        	var go = Resources.Load<TObject>(resourcePath);
        	if (!ReferenceEquals(go, null)) return go;
        	Debug.LogError($"It's Object not is Resources on resourcePath{resourcePath}");
        	return null;
        }
		
		public TComponent LoadComponent<TComponent>(string resourcePath) where TComponent : Component
		{
			var go = LoadObject<GameObject>(resourcePath);
			var component = go.GetComponent<TComponent>();
			if (!ReferenceEquals(component, null)) return component;
			Debug.LogError($"It's Component not is Resources on resourcePath{resourcePath}");
			return null;
		}
	}
}