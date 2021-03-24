using System;
using System.Collections.Generic;
using ModelsSystem.Main;
using ModelsSystem.Subsidiary;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ModelsSystem
{
	public class DummyController
	{
		public IReadOnlyList<Dummy> Dummies => _dummies;
		public event Action<Dummy, int> OnAddedDummy;
		public event Action<int> OnTakeDummyOff;
		public event Action OnDummyDidNotWaitForTheOrder;
		
		private readonly List<Dummy> _dummies = new List<Dummy>();
		private readonly List<int> _freeSpaces = new List<int>();
		private float _nextSpawnTime;
		private readonly int _maxQuantityDummy;
		private readonly int _maxQuantityFiguresAtDummy;
		private readonly int _maxQuantityTypeFigures;
		private readonly int _minIntervalSpawnDummy;
		private readonly int _maxIntervalSpawnDummy;
		private readonly float _minTimeToLeaveDummy;
		private readonly float _maxTimeToLeaveDummy;

		public DummyController(Messenger messenger, int maxQuantityDummy,
			int maxQuantityFiguresAtDummy, int maxQuantityTypeFigures,
			int minIntervalSpawnDummy, int maxIntervalSpawnDummy,
			float minTimeToLeaveDummy, float maxTimeToLeaveDummy)
		{
			_maxQuantityDummy = maxQuantityDummy;
			_maxQuantityFiguresAtDummy = maxQuantityFiguresAtDummy;
			_maxQuantityTypeFigures = maxQuantityTypeFigures;
			_minIntervalSpawnDummy = minIntervalSpawnDummy;
			_maxIntervalSpawnDummy = maxIntervalSpawnDummy;
			_minTimeToLeaveDummy = minTimeToLeaveDummy;
			_maxTimeToLeaveDummy = maxTimeToLeaveDummy;
			PrepareClearList();
			messenger.OnEndedGame += DisableAllObjectSubscription;
		}
		
		public void Update()
		{
			for (int i = 0; i < _dummies.Count; i++)
			{
				if(ReferenceEquals(_dummies[i], null) || !_dummies[i].Timer.UpdateAndCheckEndedToTimer())
					continue;

				TakeDummyOff(i);
				OnDummyDidNotWaitForTheOrder?.Invoke();
			}
			
			if(_nextSpawnTime > Time.time ||
			   _freeSpaces.Count == 0)
				return;

			_nextSpawnTime = 
				Time.time + Random.Range(_minIntervalSpawnDummy, _maxIntervalSpawnDummy + 1);
			
			SpawnDummy();
		}

		public Dummy TakeDummyOff(int dummyIndex)
		{
			Dummy dummy = _dummies[dummyIndex];
			_dummies[dummyIndex] = null;
			_freeSpaces.Add(dummyIndex);
			dummy.Clear();
			OnTakeDummyOff?.Invoke(dummyIndex);
			return dummy;
		}

		private void SpawnDummy()
		{
			int quantityAddedDummy = Random.Range(1, _freeSpaces.Count + 1);
			
			for (var i = 0; i < quantityAddedDummy; i++)
			{
				AddedDummy(new Dummy(
					_maxQuantityFiguresAtDummy, _maxQuantityTypeFigures,
					new Timer(Random.Range(_minTimeToLeaveDummy, _maxTimeToLeaveDummy + 1))));
			}
		}
		
		private void AddedDummy(Dummy dummy)
		{
			int freeIndex = _freeSpaces[0];
			_dummies[freeIndex] = dummy;
			_freeSpaces.RemoveAt(0);
			OnAddedDummy?.Invoke(dummy, freeIndex);
		}
		
		private void PrepareClearList()
		{
			for (var i = 0; i < _maxQuantityDummy; i++)
            {
            	_dummies.Add(null);
                _freeSpaces.Add(i);
            }
		}

		private void DisableAllObjectSubscription()
		{
			foreach (var dummy in _dummies)
			{
				dummy?.Clear();
			}

			_freeSpaces.Clear();
			
			for (int i = 0; i < _maxQuantityDummy; i++)
			{
				_dummies[i] = null;
				_freeSpaces.Add(i);
			}
		}
	}
}