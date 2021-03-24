using System.Collections.Generic;
using ModelsSystem;
using ModelsSystem.Main;
using ModelsSystem.Subsidiary;
using ToolsSystem.Test;
using UnityEngine;

namespace UISystem
{
	public class UIManagerSubscriptions
	{
		private Arm _arm;
		private CameraPositionConverter _cameraPositionConverter;
		private RepositoriesUIElements _repositoriesUIElements;
		private float _dummyBarOffsetByY;
		
		public UIManagerSubscriptions(Arm arm, Messenger messenger,
			RepositoriesUIElements repositoriesUIElements, CameraPositionConverter cameraPositionConverter,
			float dummyBarOffsetByY)
		{
			_arm = arm;
			_repositoriesUIElements = repositoriesUIElements;
			_cameraPositionConverter = cameraPositionConverter;
			_dummyBarOffsetByY = dummyBarOffsetByY;
			
			messenger.OnGetBarDummy += GetBarSubscription;
			messenger.OnChangeTimeGame += ChangeTimeGameSubscription;
			messenger.OnChangeScore += ChangeScoreSubscription;
			messenger.OnDisconnectionUIButton += DisconnectionUIButtonSubscription;
			messenger.OnEndedGame += DisableAllUI;
			messenger.OnStartANewGame += NewGameSubscription;
			messenger.OnInclusionUIButton += InclusionUIButtonSubscription;
		}
		
		private void DisconnectionUIButtonSubscription()
		{
			foreach (var button in _repositoriesUIElements.Buttons)
			{
				button.enabled = false;
			}
		}
		
		private void InclusionUIButtonSubscription()
		{
			foreach (var button in _repositoriesUIElements.Buttons)
			{
				button.enabled = true;
			}
		}

		private void ChangeScoreSubscription(int score)
		{
			_repositoriesUIElements.GameScoreCount.text = $"Score: {score}";
			_repositoriesUIElements.WindowRestartScoreCount.text = $"Score: {score}";
		}

		private void ChangeTimeGameSubscription(float residualTimeGame)
		{
			_repositoriesUIElements.TimeCount.text = $"Time {(int) (residualTimeGame / 60)}:{(int) (residualTimeGame % 60)}";
		}

		private void DisableAllUI()
		{
			ControllUI(false);
			_repositoriesUIElements.RestartWindow.SetActive(true);
		}

		private void NewGameSubscription()
		{
			ControllUI(true);
			_repositoriesUIElements.RestartWindow.SetActive(false);
		}

		private void ControllUI(bool enabled)
		{
			foreach (var button in _repositoriesUIElements.Buttons)
            {
            	button.gameObject.SetActive(enabled);
            }

			_repositoriesUIElements.GameScoreCount.gameObject.SetActive(enabled);
            _repositoriesUIElements.TimeCount.gameObject.SetActive(enabled);
		}
		
		private void GetBarSubscription(Dummy dummy, List<FigureType> figures, Vector3 positionDummy, Timer timer)
		{
			var bar = _arm.GetObject<DummyBar>(_arm.PathToObjectSettings.PathToBar);
			bar.Assign(dummy, timer, _repositoriesUIElements.ChangedCanvas);
			Transform barTransform = bar.transform;
			barTransform.SetParent(_repositoriesUIElements.ChangedCanvas.transform);
			barTransform.position =
				_cameraPositionConverter.Convert3dTo2d(positionDummy) - new Vector3(0f, _dummyBarOffsetByY, 0f);
			barTransform.localScale = Vector3.one;
			
			for (int j = 0; j < figures.Count; j++)
			{
				var figure = _arm.GetFigure(Decoder.TypeDecryption.UI, figures[j]);
				bar.AddFigure(figure.gameObject);
			}
		}
	}
}