using System.Collections.Generic;
using InitializeSystem;
using UnityEngine;

namespace ToolsSystem
{
	public class MonoBehaviourManager : MonoBehaviour
	{
		private List<IAction> _actions = new List<IAction>();

		private void Update()
		{
			foreach (IAction action in _actions)
			{
				if (action.disabled) continue;
				
				action.Tick();
			}
		}

		public TComponent InstantiateGameObjectByComponent<TComponent>(TComponent component) where TComponent : Component
		{
			return Instantiate(component);
		}
		public GameObject InstantiateGameObject(GameObject go)
		{
			return Instantiate(go);
		}
		
		public void AddAction(IAction action)
		{
			_actions.Add(action);
		}
	}
}