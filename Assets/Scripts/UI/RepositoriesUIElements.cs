using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
	public class RepositoriesUIElements : MonoBehaviour
	{
		public List<Button> Buttons;
		public Text GameScoreCount;
		public Text WindowRestartScoreCount;
		public Text TimeCount;
		public Camera Camera3d;
		public Camera Camera2d;
		public Canvas ChangedCanvas;
		public GameObject RestartWindow;
	}
}