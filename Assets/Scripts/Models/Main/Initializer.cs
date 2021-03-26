using ModelsSystem.Subsidiary;
using SettingsSystem;
using UISystem;
using UnityEngine;
using ViewSystem;

namespace ModelsSystem.Main
{
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private ConveyorView _conveyorView;
		[SerializeField] private DummyControllerView _dummyControllerView;
		[SerializeField] private RepositoriesUIElements _repositoriesUIElements;
		[SerializeField] private UIController _uiController;
		
		public void Initialize(
			ref Messenger messenger, ref GameSettings gameSettings, ref DummyController dummyController, ref Conveyor conveyor, ref OrdersInspection ordersInspection)
		{
			 messenger = new Messenger();
			
			 gameSettings = Resources.Load<GameSettings>("Settings/GameSettings");
            
			 var animationSettings = Resources.Load<AnimationSettings>("Settings/AnimationSettings");
			 
             var arm = new Arm(new Decoder(
            	Resources.Load<FigureSettings>("Settings/GOFigureSettings"), 
            	Resources.Load<FigureSettings>("Settings/UIFigureSettings")
            	));
            
			 conveyor = new Conveyor(messenger,
	            gameSettings.MAXQuantityDummy, gameSettings.MAXQuantityFiguresAtTray);
             
            _conveyorView.Assign(conveyor, arm, messenger, animationSettings);
            
             dummyController = new DummyController(messenger, gameSettings.MAXQuantityDummy, 3, 3,
	            gameSettings.MINIntervalSpawnDummy, gameSettings.MAXIntervalSpawnDummy, gameSettings.MINTimeToLeaveDummy,
	            gameSettings.MINTimeToLeaveDummy);
             
             _dummyControllerView.Assign(dummyController, arm, messenger, animationSettings, _conveyorView);
            
             var uiManager = new UIManager(arm, messenger, gameSettings, _repositoriesUIElements, _uiController);
             
             ordersInspection = new OrdersInspection(conveyor, dummyController, gameSettings.MAXQuantityDummy);
		}
	}
}