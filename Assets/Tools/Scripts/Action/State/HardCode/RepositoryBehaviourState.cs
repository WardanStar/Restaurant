using ToolsSystem.Action.StateSystem.Abstract;

namespace ToolsSystem.Action.StateSystem
{
	public class RepositoryBehaviourState
	{
		public RepositoryBehaviourState(params BehaviourStateInfo[] behaviourStateInfos)
		{
			BehaviourStateInfos = behaviourStateInfos;
		}

		public class BehaviourStateInfo
		{
			public string keyBehaviourState;
			public BehaviourState behaviourState;

			public BehaviourStateInfo(string keyBehaviourState, BehaviourState behaviourState)
			{
				this.keyBehaviourState = keyBehaviourState;
				this.behaviourState = behaviourState;
			}
		}

		public BehaviourStateInfo[] BehaviourStateInfos { get; }
	}
}