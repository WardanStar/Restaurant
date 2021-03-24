using ToolsSystem.Action.StateSystem.Abstract;

namespace ToolsSystem.Action.StateSystem
{
	public class StateManager
	{
		public StateManager(RepositoryBehaviourState repositoryBehaviourState, string keyStartState, params StateInfo[] stateInfos)
		{
			_stateInfos = stateInfos;
			_repositoryBehaviourState = repositoryBehaviourState;
			_keyStartState = keyStartState;
			foreach (StateInfo stateInfo in _stateInfos)
			{
				stateInfo.stateConstructor.Initialize(this);
			}
			SetState(keyStartState);
		}

		public class StateInfo
		{
			public string keyStateConstructor;
			public StateConstructor stateConstructor;
			
			public StateInfo(string keyStateConstructor, StateConstructor stateConstructor)
			{
				this.keyStateConstructor = keyStateConstructor;
				this.stateConstructor = stateConstructor;
			}
		}
		
		private StateInfo[] _stateInfos;
		private RepositoryBehaviourState _repositoryBehaviourState;
		private StateConstructor _state;
		private string _keyStartState;

		public void Update()
		{
			if (_state.Ended)
				return;
			
			_state.Update();
		} 
		
		public void SetState(string key)
		{
			_state = GetStateConstructor(key);
		}

		public void StartOver()
		{
			SetState(_keyStartState);
		}

		private StateConstructor GetStateConstructor(string key)
		{
			StateConstructor state = null;
			
			foreach (StateInfo stateInfo in _stateInfos)
			{
				if(stateInfo.keyStateConstructor != key) 
					continue;

				state = stateInfo.stateConstructor;
				break;
			}

			return state;
		}

		public BehaviourState GetBehaviourState(string key)
		{
			BehaviourState behaviourState = null;
			
			foreach (RepositoryBehaviourState.BehaviourStateInfo behaviourStateInfo
				in _repositoryBehaviourState.BehaviourStateInfos)
			{
				if(behaviourStateInfo.keyBehaviourState != key)
					continue;

				behaviourState = behaviourStateInfo.behaviourState;
				break;
			}

			return behaviourState;
		}
	}
}