using System;
using System.Collections.Generic;
using ModelsSystem.Subsidiary;
using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class FigureSettings : ScriptableObject
	{
		[Serializable]
		public struct FigureInfo
		{
			public FigureType _figureType;
			public string pathToFigure;
		}

		public List<FigureInfo> FigureInfos => _figureInfos;
		[SerializeField] private List<FigureInfo> _figureInfos;
	}
}