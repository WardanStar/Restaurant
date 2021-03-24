using System.Collections.Generic;
using DG.Tweening;
using ModelsSystem;
using ModelsSystem.Main;
using ModelsSystem.Subsidiary;
using UnityEngine;

namespace ViewSystem
{
	public class DummyView : MonoBehaviour
	{
		private Dummy _dummy;
		private Messenger _messenger;

		[SerializeField] private Transform _repositoryTray;
		
		private float _timeOfApproachToTheCheckout;
		
		public void Assign(Dummy dummy, Messenger messenger, float timeOfApproachToTheCheckout)
		{
			if (_dummy != null)
			{
				_dummy.OnMakeAnOrder -= OnDummyMakeAnOrder;
			}

			_dummy = dummy;
			_messenger = messenger;
			_timeOfApproachToTheCheckout = timeOfApproachToTheCheckout;
			_dummy.OnMakeAnOrder += OnDummyMakeAnOrder;
			messenger.OnEndedGame += () => gameObject.SetActive(false);
		}

		public void GoToTheCheckout(Vector3 pointTravel)
		{
			gameObject.transform.DOMove(pointTravel, _timeOfApproachToTheCheckout).OnComplete(() => _dummy.MakeAnOrder());
		}
		
		private void OnDummyMakeAnOrder(List<FigureType> figures, Timer dummyTimer)
        {
        	_messenger.OnGetBarDummyMailing(_dummy, figures, transform.position, dummyTimer);
        }

		public void TakeTrayAndGoAway(TrayView trayView)
		{
			trayView.transform.parent = _repositoryTray;
			OnDummyGoAway();
		}
		
		public void OnDummyGoAway()
		{
			transform.DOMove(transform.position + new Vector3(0f, 0f, 1f), 2f)
				.OnComplete(() => transform.DOMove(transform.position + new Vector3(20f, 0f, 0f), 7f)
				.OnComplete(() => gameObject.SetActive(false)));
		}

		private void OnDisable()
		{
			if(_repositoryTray.childCount == 0)
				return;

			_repositoryTray.GetChild(0).gameObject.SetActive(false);
			_repositoryTray.DetachChildren();
		}
	}
}