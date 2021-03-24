using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class AnimationSettings : ScriptableObject
	{
		public float TimeOfApproachToTheCheckout => _timeOfApproachToTheCheckout;

		[Header("Dummy")]
		[SerializeField] private float _timeOfApproachToTheCheckout;
	}
}