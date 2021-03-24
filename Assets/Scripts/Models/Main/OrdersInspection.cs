using System;

namespace ModelsSystem.Main
{
	public class OrdersInspection
	{
		private Conveyor _conveyor;
		private DummyController _dummyController;

		public event Action OnDummyReceivedAnOrder;

		private int _maxQuantityDummy;

		public OrdersInspection(Conveyor conveyor, DummyController dummyController, int maxQuantityDummy)
		{
			_conveyor = conveyor;
			_dummyController = dummyController;
			_maxQuantityDummy = maxQuantityDummy;
		}
		
		public void CheckOrder()
		{
			for (int i = 0; i < _maxQuantityDummy; i++)
			{
				if (_conveyor.Trays[i] == null || _dummyController.Dummies[i] == null ||
				    _conveyor.Trays[i].Figures.Count != _dummyController.Dummies[i].Figures.Count ||
				    !Inspection(i))
					continue;

            	_conveyor.TakeTrayOff(i);
            	_dummyController.TakeDummyOff(i);
            	OnDummyReceivedAnOrder?.Invoke();
            }
		}

		private bool Inspection(int index)
		{
			var currentDummy = _dummyController.Dummies[index];
			var currentTray = _conveyor.Trays[index];
			
			for (int i = 0; i < currentTray.Figures.Count; i++)
			{
				if (currentTray.Figures[i] != currentDummy.Figures[i])
					return false;
			}

			return true;
		}
	}
}