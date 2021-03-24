using AudioSystem;
using ResourcesLoadSystem;
using UnityEngine;

namespace ToolsSystem
{
	public class ToolsData
	{
		public ToolsData()
		{
			var go = new GameObject("Tools");
			monoBehaviourManager = go.AddComponent<MonoBehaviourManager>();
            getObjectManager = new GetObjectManager(new ResourceLoadManager(),
	            new PoolManager() , monoBehaviourManager);
            
            audioManager = new AudioManager(getObjectManager);
		}

		public MonoBehaviourManager monoBehaviourManager { get; }
		public GetObjectManager getObjectManager { get; }
		public AudioManager audioManager { get; }
	}
}