using InitializeSystem;
using UnityEngine;

namespace ActionSystem
{
	public class AudioDisable : MonoBehaviour, IInitialize<AudioSource>
	{
		public void Assign(AudioSource audioSource)
		{
			_audioSource = audioSource;
		}

		private AudioSource _audioSource;

		private void Update()
		{
			if (!_audioSource.isPlaying)
				gameObject.SetActive(false);
		}
	}
}