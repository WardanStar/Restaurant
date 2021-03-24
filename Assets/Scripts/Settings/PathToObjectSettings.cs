using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class PathToObjectSettings : ScriptableObject
	{
		public string PathToTray => pathToTray;
		public string PathToDummy => pathToDummy;
		public string PathToBar => pathToBar;

		[SerializeField] private string pathToTray;
		[SerializeField] private string pathToDummy;

		[Header("UI")]
		[SerializeField] private string pathToBar;
	}
}