using System.Collections.Generic;
using ModelsSystem;
using ModelsSystem.Subsidiary;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
	public class DummyBar : MonoBehaviour
	{
		public GameObject _figureBackGround;
		public Image _bar;

		private readonly List<GameObject> _listFigure = new List<GameObject>();
		private Canvas _changeCanvas;
		private Timer _timer;

		public void Assign(Dummy dummy, Timer timer, Canvas changeCanvas)
        {
        	_timer = timer;
            _changeCanvas = changeCanvas;
            dummy.OnClear += OnDummyClear;
        }

		public void AddFigure(GameObject figure)
        {
        	_listFigure.Add(figure);
        	figure.transform.SetParent(_figureBackGround.transform);
        	figure.transform.localScale = Vector3.one;
        	var trans = figure.GetComponent<RectTransform>();
        	var anchoredPosition3D = trans.anchoredPosition3D;
        	anchoredPosition3D = new Vector3(anchoredPosition3D.x, anchoredPosition3D.y, 0f);
        	trans.anchoredPosition3D = anchoredPosition3D;
        }
		
		private void Update()
        {
        	if(ReferenceEquals(_timer, null))
        		return;
        	_bar.fillAmount = 1 - _timer.InterpolationTime;
        }
		
		private void OnDummyClear()
		{
			foreach (GameObject go in _listFigure)
            {
            	go.SetActive(false);
            	go.transform.SetParent(_changeCanvas.transform);
            }
            _listFigure.Clear();
            
            gameObject.SetActive(false);
		}
	}
}