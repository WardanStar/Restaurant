using System;
using System.Collections.Generic;
using ModelsSystem.Main;
using ModelsSystem.Subsidiary;

namespace ModelsSystem
{
	public class Conveyor
	{
		public IReadOnlyList<Tray> Trays => _trays; 
		public event Action OnMove;
		public event Action<Tray> OnAddedTray;
		public event Action<int> OnTakeTrayOff;
		
		private readonly List<Tray> _trays = new List<Tray>();
		private readonly int _maxTraysToConveyor;
		private readonly int _maxFiguresQuantity;
		private Tray _controlledTray;
		
		public Conveyor(Messenger messenger, int maxTraysToConveyor, int maxFiguresQuantity)
		{
			_maxTraysToConveyor = maxTraysToConveyor;
			_maxFiguresQuantity = maxFiguresQuantity;
			messenger.OnMoveToConveyor += MoveTrays;
			messenger.OnAddedFigure += AddFigureInTray;
			messenger.OnStartANewGame += StartGame;
			messenger.OnEndedGame += DisableAllObjectSubscription;
			PrepareClearList();
		}
		
		public Tray TakeTrayOff(int trayIndex)
		{
			OnTakeTrayOff?.Invoke(trayIndex);
			return PullOutTray(trayIndex);
		}

		private void StartGame()
		{
			AddTrayToConveyor(new Tray(_maxFiguresQuantity));
		}
		
		private void MoveTrays()
		{
			if (!ReferenceEquals(_trays[_trays.Count - 1], null))
			{
				PullOutTray(_trays.Count - 1);
			}

	        for (var i = _maxTraysToConveyor - 1; i > 0; i--)
        	{
        		_trays[i] = _trays[i - 1];
        	}

	        _trays[0] = _controlledTray;
	        
        	OnMove?.Invoke();
        	
        	AddTrayToConveyor(new Tray(_maxFiguresQuantity));
        } 
		
		private void AddTrayToConveyor(Tray tray)
		{
			_controlledTray = tray;
			OnAddedTray?.Invoke(tray);
		}
		
		private void AddFigureInTray(FigureType figureType)
		{
			_controlledTray.AddFigure(figureType);
		}
		
		private Tray PullOutTray(int trayIndex)
        {
        	Tray tray = _trays[trayIndex];
            tray.Clear();
        	_trays[trayIndex] = null;
        	return tray;
        }
		
		private void PrepareClearList()
		{
			for (int i = 0; i < _maxTraysToConveyor; i++)
			{
				_trays.Add(null);
			}
		}

		private void DisableAllObjectSubscription()
		{
			_controlledTray.Clear();
			_controlledTray = null;
			
			foreach (var tray in _trays)
			{
				tray?.Clear();
			}
			
			for (int i = 0; i < _maxTraysToConveyor; i++)
			{
				_trays[i] = null;
			}
		}
	}
}