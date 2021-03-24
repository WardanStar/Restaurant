using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class GameSettings : ScriptableObject
	{
		public float TimeToGameEnded => _timeToGameEnded;
		public int QuantityTrayAtStart => quantityTrayAtStart;
		public int MAXQuantityFiguresAtTray => maxQuantityFiguresAtTray;
		public int MAXQuantityDummy => maxQuantityDummy;
		public int MINIntervalSpawnDummy => minIntervalSpawnDummy;
		public int MAXIntervalSpawnDummy => maxIntervalSpawnDummy;
		public float MINTimeToLeaveDummy => minTimeToLeaveDummy;
		public float MAXTimeToLeaveDummy => maxTimeToLeaveDummy;
		public float OffsetByY => _offsetByY;

		[Header("Game")]
		[SerializeField] private float _timeToGameEnded;
		[Header("Tray")]
		[SerializeField] private int quantityTrayAtStart;
		[SerializeField] private int maxQuantityFiguresAtTray;
		[Header("Dummy")]
		[SerializeField] private int maxQuantityDummy;
		[SerializeField] private int minIntervalSpawnDummy;
		[SerializeField] private int maxIntervalSpawnDummy;
		[SerializeField] private float minTimeToLeaveDummy;
		[SerializeField] private float maxTimeToLeaveDummy;
		[Header("DummyBar")]
		[SerializeField] private float _offsetByY;
	}
}