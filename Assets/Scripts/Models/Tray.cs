using System;
using System.Collections.Generic;
using ModelsSystem.Subsidiary;

namespace ModelsSystem
{
	public class Tray
	{
		public IReadOnlyList<FigureType> Figures => _figures;
		public event Action<FigureType> OnFigureAdded;
		public event Action OnTrayCleared;
		
		private readonly int _maxFiguresQuantity;
		private readonly List<FigureType> _figures = new List<FigureType>();

		public Tray(int maxFiguresQuantity)
		{
			_maxFiguresQuantity = maxFiguresQuantity;
		}

		public void AddFigure(FigureType figureType)
		{
			if(_figures.Count == _maxFiguresQuantity)
				return;
			
			_figures.Add(figureType);
			
			OnFigureAdded?.Invoke(figureType);
		}

		public void Clear()
		{
			_figures.Clear();
			OnTrayCleared?.Invoke();
		}
	}
}