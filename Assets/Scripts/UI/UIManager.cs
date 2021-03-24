using ModelsSystem.Main;
using SettingsSystem;
using ToolsSystem.Test;

namespace UISystem
{
	public class UIManager
	{
		private UIManagerSubscriptions _uiManagerSubscriptions;
		
		public UIManager(Arm arm, Messenger messenger, GameSettings gameSettings, RepositoriesUIElements repositoriesUIElements, UIController uiController)
		{
			var cameraPositionConverter = new CameraPositionConverter(
				repositoriesUIElements.Camera3d, repositoriesUIElements.Camera2d, repositoriesUIElements.ChangedCanvas);

			_uiManagerSubscriptions = new UIManagerSubscriptions(arm, messenger, repositoriesUIElements, cameraPositionConverter, gameSettings.OffsetByY);
			
			uiController.Assign(messenger);
		}
	}
}