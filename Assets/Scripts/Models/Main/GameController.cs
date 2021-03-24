using DG.Tweening;
using ModelsSystem.Subsidiary;
using SettingsSystem;
using UnityEngine;

namespace ModelsSystem.Main
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private Initializer _initializer;

		private Conveyor _conveyor;
		private DummyController _dummyController;
		private Messenger _messenger;
		private OrdersInspection _ordersInspection;

		private Timer _timer;
		private bool disable;
		private int _score;

		private void Awake()
		{
			GameSettings gameSettings = null;
			_initializer.Initialize(ref _messenger, ref gameSettings, ref _dummyController, ref _conveyor, ref _ordersInspection);
			
			_timer = new Timer(gameSettings.TimeToGameEnded);
			_ordersInspection.OnDummyReceivedAnOrder += OnOrdersInspectionDummyReceivedAnOrder;
			_dummyController.OnDummyDidNotWaitForTheOrder += OnDummyControllerDummyDidNotWaitForTheOrder;
			_conveyor.OnMove += OnConveyorMove;
		}

		private void Start()
		{
			_messenger.OnStartANewGameMailing();
			_timer.StartTimer();
			_messenger.OnStartANewGame += OnMessengerStartANewGame;
		}

		private void Update()
		{
			if(disable)
				return;
			
			_messenger.OnChangeTimeGameMailing(_timer.ResidualTime);
			
			if (_timer.UpdateAndCheckEndedToTimer())
			{
				_messenger.OnEndedGameMailing();
				DOTween.Clear();
				disable = true;
				return;
			}
			
			_dummyController.Update();
		}
		
		private void OnMessengerStartANewGame()
        {
        	disable = false;
            _timer.StartTimer();
            _score = 0;
            _messenger.OnChangeScoreMailing(_score);
        }
		
		private void OnConveyorMove()
        {
        	_ordersInspection.CheckOrder();
        }
		
		private void OnOrdersInspectionDummyReceivedAnOrder()
        {
	        ++_score;
	        _messenger.OnChangeScoreMailing(_score);
        }
		
		private void OnDummyControllerDummyDidNotWaitForTheOrder()
		{
			--_score;
			_messenger.OnChangeScoreMailing(_score);
		}
		
	}
}