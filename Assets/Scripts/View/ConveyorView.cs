using System;
using System.Collections.Generic;
using DG.Tweening;
using ModelsSystem;
using ModelsSystem.Main;
using UnityEngine;

namespace ViewSystem
{
	public class ConveyorView : MonoBehaviour
	{
		private Arm _arm;
		private Conveyor _conveyor;
		private Messenger _messenger;

		public event Action<int, TrayView> OnTakeTrayOff;
		
		[SerializeField] private List<Transform> _slots;
		[SerializeField] private Transform _stackTraysSlot;
		[SerializeField] private Transform _trashSlot;
		
		private readonly List<TrayView> _trays = new List<TrayView>();
		private TrayView _controlledTrayView;
		
		public void Assign(Conveyor conveyor, Arm arm, Messenger messenger)
		{
			_conveyor = conveyor;
			_arm = arm;
			_messenger = messenger;
			_conveyor.OnMove += OnConveyorMove;
			_conveyor.OnAddedTray += OnConveyorAddedTray;
			_conveyor.OnTakeTrayOff += OnConveyorTakeTrayOff;
			Initialize();
		}

		private void OnConveyorTakeTrayOff(int index)
		{
			var trayView = _trays[index];
			_trays[index] = null;
			OnTakeTrayOff?.Invoke(index, trayView);
		}

		private void OnConveyorAddedTray(Tray tray)
		{
			var trayView = _arm.GetObject<TrayView>(
				_arm.PathToObjectSettings.PathToTray, _stackTraysSlot.position, transform.rotation);
			trayView.Assign(tray, _arm, _messenger);

			_controlledTrayView = trayView;
		}

		private void OnConveyorMove()
		{
			for (int i = 0; i < _trays.Count; i++)
			{
				if(ReferenceEquals(_trays[i], null))
					continue;

				if (i == _trays.Count - 1)
				{
					var tray = _trays[_trays.Count - 1];

					_trays[_trays.Count - 1].transform.DOJump(_trashSlot.position, 2f, 1, 2f).OnComplete(tray.Disable);
					_trays[_trays.Count - 1] = null;
					break;
				}
				
				_trays[i].transform.DOMove(_slots[i + 1].position, 1f);
			}
			
			for (var i = _trays.Count - 1; i > 0; i--)
			{
				_trays[i] = _trays[i - 1];
			}
			
			_controlledTrayView.transform.DOMove(_slots[0].position, 2f);
			_trays[0] = _controlledTrayView;
			_controlledTrayView = null;
		}

		private void Initialize()
		{
			for (int i = 0; i < _slots.Count; i++)
			{
				_trays.Add(null);
			}
		}
	}
}