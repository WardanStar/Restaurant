using ModelsSystem.Subsidiary;
using ResourcesLoadSystem;
using SettingsSystem;
using ToolsSystem;
using UnityEngine;

namespace ModelsSystem.Main
{
	public class Arm
	{
		public Arm(Decoder decoder)
		{
			_decoder = decoder;
			Initialize();
		}
		
		private GetObjectManager _getObjectManager;
		public PathToObjectSettings PathToObjectSettings { get; private set; }
		private Decoder _decoder;

		public T GetObject<T>(string pathToObject) where T : Component
		{
			return _getObjectManager.GetObject<T>(pathToObject);
		}
		public T GetObject<T>(string pathToObject, Vector3 position, Quaternion rotation) where T : Component
		{
			return _getObjectManager.GetObject<T>(pathToObject, position, rotation);
		}
		
		public Transform GetFigure(Decoder.TypeDecryption typeDecryption, FigureType figureType)
		{
			var pathToObject = _decoder.DecryptionFigure(typeDecryption, figureType);
			return _getObjectManager.GetObject<Transform>(pathToObject);
		}

		public T GetInfoComponent<T>(string pathToObject) where T : Component
		{
			return _getObjectManager.GetInfoComponent<T>(pathToObject);
		}
		
		private void Initialize()
		{
			_getObjectManager = new GetObjectManager(new ResourceLoadManager(),
            	new PoolManager() , new GameObject("MonoBehaviourManager").AddComponent<MonoBehaviourManager>());
            PathToObjectSettings = Resources.Load<PathToObjectSettings>("Settings/PathToObjectSettings");
		}
	}
}