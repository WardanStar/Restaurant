namespace ToolsSystem.Action.StateSystem.Abstract
{
	public abstract class BehaviourState
	{
		public virtual bool Update()
		{
			var ended = false;
			return ended;
		}
	}
}