using UnityEngine;

namespace ToolsSystem.Action.StateSystem.Abstract
{
	public abstract class State : StateMachineBehaviour
	{
		public virtual void Update(){}
		public virtual void OnEnter(){}
		public virtual void OnExit(){}

		protected StateManager StateManager;
		
		public virtual void Initialize(StateManager stateManager){}
	}
}