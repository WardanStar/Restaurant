namespace InitializeSystem
{
	public interface IWeaponController
	{ 
		void Shot();
	}

	public interface IAction
	{
		void Tick();
		bool disabled { get; set; }
	}
}