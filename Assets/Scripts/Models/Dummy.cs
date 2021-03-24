using System;
using System.Collections.Generic;
using ModelsSystem.Subsidiary;
using Random = UnityEngine.Random;

namespace ModelsSystem
{
	public class Dummy
	{
		public IReadOnlyList<FigureType> Figures => _figures;
		public event Action<List<FigureType>, Timer> OnMakeAnOrder;
		public event Action OnClear;
		public Timer Timer { get; }
		
		private readonly List<FigureType> _figures = new List<FigureType>();
		
		public Dummy(int maxFigureAtDummy, int quantityTypeFigures, Timer timer)
		{
			Timer = timer;
			for (int i = 0; i < maxFigureAtDummy; i++)
            {
                _figures.Add((FigureType)Random.Range(0, quantityTypeFigures));
            }
		}
		
		public void MakeAnOrder()
		{
			Timer.StartTimer();
			OnMakeAnOrder?.Invoke(_figures, Timer);
		}

		public void Clear()
		{
			_figures.Clear();
			OnClear?.Invoke();
		}
	}
}