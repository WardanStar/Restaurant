using ModelsSystem.Main;
using ModelsSystem.Subsidiary;
using UnityEngine;

namespace UISystem
{
	public class UIController : MonoBehaviour
	{
		private Messenger _messenger;

		public void Assign(Messenger messenger)
		{
			_messenger = messenger;
		}
		
		public void AddedFigureToTraySubscription(int figureType)
		{
			_messenger.OnAddedFigureMailing((FigureType)figureType);
		}

		public void MoveToConveyorSubscription()
		{
			_messenger.OnMoveToConveyorMailing();
		}

		public void StartNewGame()
		{
			_messenger.OnStartANewGameMailing();
		}
	}
}