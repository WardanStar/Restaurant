using System;
using System.Collections.Generic;
using ModelsSystem.Subsidiary;
using UnityEngine;

namespace ModelsSystem.Main
{
	public class Messenger
	{
		public event Action OnDisconnectionUIButton;
		public event Action OnInclusionUIButton;
		public event Action OnMoveToConveyor;
		public event Action OnEndedGame;
		public event Action OnStartANewGame;
		public event Action<FigureType> OnAddedFigure;
		public event Action<Dummy, List<FigureType>, Vector3, Timer> OnGetBarDummy;
		public event Action<float> OnChangeTimeGame;
		public event Action<int> OnChangeScore;

		public void OnDisconnectionUIButtonMailing()
		{
			OnDisconnectionUIButton?.Invoke();
		}

		public void OnInclusionUIButtonMailing()
		{
			OnInclusionUIButton?.Invoke();
		}

		public void OnMoveToConveyorMailing()
		{
			OnMoveToConveyor?.Invoke();
		}

		public void OnEndedGameMailing()
		{
			OnEndedGame?.Invoke();
		}

		public void OnStartANewGameMailing()
        {
        	OnStartANewGame?.Invoke();
        }
		
		public void OnAddedFigureMailing(FigureType obj)
		{
			OnAddedFigure?.Invoke(obj);
		}

		public void OnGetBarDummyMailing(Dummy dummy, List<FigureType> figures, Vector3 positionDummy, Timer timer)
		{
			OnGetBarDummy?.Invoke(dummy, figures, positionDummy, timer);
		}

		public void OnChangeTimeGameMailing(float obj)
		{
			OnChangeTimeGame?.Invoke(obj);
		}

		public void OnChangeScoreMailing(int obj)
		{
			OnChangeScore?.Invoke(obj);
		}
	}
}