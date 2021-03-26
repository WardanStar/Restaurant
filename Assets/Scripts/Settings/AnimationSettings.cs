using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class AnimationSettings : ScriptableObject
	{
		public float TimeOfApproachToTheCheckout => _timeOfApproachToTheCheckout;
		public float SpeedConveyor => _speedConveyor;

		[Header("Dummy")]
		[SerializeField] private float _timeOfApproachToTheCheckout;
		[Header("Conveyor")]
		[SerializeField] private float _speedConveyor;
	}
}