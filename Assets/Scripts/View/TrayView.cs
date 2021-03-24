using ModelsSystem;
using ModelsSystem.Main;
using ModelsSystem.Subsidiary;
using UnityEngine;

namespace ViewSystem
{
	public class TrayView : MonoBehaviour
	{
		[SerializeField] private Transform[] _slots;

		private Arm _arm;
		private Tray _tray;
		
		private int _curentSlotIndex;
		
		public void Assign(Tray tray, Arm arm, Messenger messenger)
		{
			if (_tray != null)
			{
				_tray.OnFigureAdded -= OnTrayFigureAdded;
			}
			
			_tray = tray;
			_arm = arm;
			_tray.OnFigureAdded += OnTrayFigureAdded;
			messenger.OnEndedGame += () => gameObject.SetActive(false);
		}

		private void OnTrayFigureAdded(FigureType figureType)
		{
			Transform figureTransform = _arm.GetFigure(Decoder.TypeDecryption.GameObject, figureType);
			figureTransform.position = _slots[_curentSlotIndex].position;
			figureTransform.SetParent(_slots[_curentSlotIndex]);
			_curentSlotIndex++;
		}

		
		
		private void Clear()
		{
			for (int i = 0; i < _slots.Length; i++)
			{
				if(_slots[i].childCount == 0)
					continue;
				
				_slots[i].GetChild(0).gameObject.SetActive(false);
				_slots[i].DetachChildren();
			}
			
			_curentSlotIndex = 0;
		}
		
		public void Disable()
        {
        	gameObject.SetActive(false);
        }
		
		private void OnDisable()
        {
        	Clear();
        }
	}
}