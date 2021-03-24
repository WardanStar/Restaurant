using JetBrains.Annotations;

namespace ToolsSystem.Action.StateSystem
{
	public class StateConstructor
	{
		public StateConstructor(params BehaviourStateInfo[] behaviourStateInfos)
		{
			_behaviourStateInfos = behaviourStateInfos;
		}

		public class BehaviourStateInfo
		{
			public string keyBehaviourState;
			public string keyStateOfTransition;
			public bool ended;

			public BehaviourStateInfo(string keyBehaviourState, [CanBeNull] string keyStateOfTransition)
			{
				this.keyBehaviourState = keyBehaviourState;
				this.keyStateOfTransition = keyStateOfTransition;
			}
		}
		
		private BehaviourStateInfo[] _behaviourStateInfos;
		private StateManager _stateManager;
		public bool Ended { get; private set; }
		
		public void Update()
		{
			foreach (BehaviourStateInfo behaviourStateInfo in _behaviourStateInfos)
			{
				if (behaviourStateInfo.ended)
					continue;
				
				if (!_stateManager.GetBehaviourState(
					behaviourStateInfo.keyBehaviourState)
					.Update())
					continue;

				behaviourStateInfo.ended = true;

				if (behaviourStateInfo.keyStateOfTransition == null)
				{
					var ended = true;
					
					foreach (BehaviourStateInfo behaviourState in _behaviourStateInfos)
					{
						if (!behaviourState.ended)
							ended = false;
					}

					if (ended)
					{
						Ended = true;
						return;
					}
					
					continue;
				}
					

				_stateManager.SetState(behaviourStateInfo.keyStateOfTransition);
				break;
			}
		}

		public void Initialize(StateManager stateManager)
		{
			_stateManager = stateManager;
		}
	}
}