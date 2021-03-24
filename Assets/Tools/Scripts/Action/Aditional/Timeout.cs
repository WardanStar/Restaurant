using InitializeSystem;
using UnityEngine;

namespace ActionSystem
{
	public class Timeout : MonoBehaviour, IInitialize<float>
	{
		private float _timeout;
		
		public void Assign(float timeout)
		{
			_timeout = timeout + Time.time;
		}

		public void Update()
		{
			if (Mathf.Approximately(_timeout, 0)) return;
			if(Time.time < _timeout) return;
			_timeout = 0;
			gameObject.SetActive(false);
		}
	}
}