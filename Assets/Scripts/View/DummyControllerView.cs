using System.Collections.Generic;
using ModelsSystem;
using ModelsSystem.Main;
using SettingsSystem;
using UnityEngine;

namespace ViewSystem
{
	public class DummyControllerView : MonoBehaviour
	{
		private Arm _arm;
		private DummyController _dummyController;
		private Messenger _messenger;
		private AnimationSettings _animationSettings;
		
		[SerializeField] private Transform _spawnPoint;
		[SerializeField] private List<Transform> _slots = new List<Transform>();
		
		private List<DummyView> _dummyViews = new List<DummyView>();
		
		public void Assign(DummyController dummyController, Arm arm, Messenger messenger, AnimationSettings animationSettings, ConveyorView conveyorView)
		{
			_arm = arm;
			_dummyController = dummyController;
			_messenger = messenger;
			_animationSettings = animationSettings;
			_dummyController.OnAddedDummy += OnDummyControllerAddedDummy;
			_dummyController.OnTakeDummyOff += TakeDummyOff;
			conveyorView.OnTakeTrayOff += TakeTrayAndGoAway;
			Initialize();
		}

		private void TakeDummyOff(int index)
		{
			_dummyViews[index].OnDummyGoAway();
		}

		private void TakeTrayAndGoAway(int index, TrayView trayView)
		{
			_dummyViews[index].TakeTrayAndGoAway(trayView);
		}

		private void OnDummyControllerAddedDummy(Dummy dummy, int index)
		{
			var dummyView = _arm.GetObject<DummyView>(_arm.PathToObjectSettings.PathToDummy, _spawnPoint.position, Quaternion.identity);
			dummyView.Assign(dummy, _messenger, _animationSettings.TimeOfApproachToTheCheckout);
			dummyView.GoToTheCheckout(_slots[index].position);
			_dummyViews[index] = dummyView;
		}

		private void Initialize()
		{
			for (int i = 0; i < _slots.Count; i++)
			{
				_dummyViews.Add(null);
			}
		}
	}
}