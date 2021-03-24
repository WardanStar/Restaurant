using System.Collections.Generic;
using SettingsSystem;

namespace ModelsSystem.Subsidiary
{
	public class Decoder
	{
		public Decoder(FigureSettings gameObjectFigureSettings, FigureSettings UIFigureSettings)
		{
			_gameObjectFigureSettings = gameObjectFigureSettings;
			_UIFigureSettings = UIFigureSettings;
		}
		
		private readonly FigureSettings _gameObjectFigureSettings;
		private readonly FigureSettings _UIFigureSettings;

		public enum TypeDecryption
		{
			GameObject,
			UI
		}
		
		public string DecryptionFigure(TypeDecryption typeDecryption, FigureType figureType)
		{
			switch (typeDecryption)
			{
				case TypeDecryption.GameObject:
					return SelectFigure(_gameObjectFigureSettings.FigureInfos, figureType);
				
				case TypeDecryption.UI:
					return SelectFigure(_UIFigureSettings.FigureInfos, figureType);
			}

			return null;
		}

		private string SelectFigure(List<FigureSettings.FigureInfo> list, FigureType figureType)
		{
			foreach (FigureSettings.FigureInfo figureDecodingInfo in list)
			{
				if(figureDecodingInfo._figureType != figureType)
					continue;

				return figureDecodingInfo.pathToFigure;
			}

			return null;
		}
	}
}