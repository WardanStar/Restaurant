using ResourcesLoadSystem;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
	public class AudioManager 
	{
		public AudioManager(GetObjectManager getObjectManager)
		{
			
			_getObjectManager = getObjectManager;
			_audioMixer = _getObjectManager.GetInfoObject<AudioMixer>("AudioMaster");
			Initialize();
		}

		private GetObjectManager _getObjectManager;
		
		private AudioMixer _audioMixer;
		private float _generalVolume;
		private float _musicVolume;
		private float _effectVolume;
		
		public void ChangeGeneralVolume(float value)
		{
			_audioMixer.SetFloat("GeneralVolume", _generalVolume = value);
		}
		public void ChangeMusicVolume(float value)
		{
			_audioMixer.SetFloat("MusicVolume", _musicVolume = value);
		}
		public void ChangeEffectVolume(float value)
		{
			_audioMixer.SetFloat("EffectVolume", _effectVolume = value);
		}

		public void OffOnMusic(bool onMusic)
		{
			if (onMusic)
				_audioMixer.SetFloat("GeneralVolume", _generalVolume);
			else
				_audioMixer.SetFloat("GeneralVolume", -80);
		}
		
		public AudioSource PlayAudio2D(string resourcesPath)
		{
			return _getObjectManager.GetObject<AudioSource>(resourcesPath);
		}

		public AudioSource PlayAudio2D(string resourcesPathBasisAudioSource, string resourcesPathAudioClip)
		{
			var component = _getObjectManager.GetObject<AudioSource>(resourcesPathBasisAudioSource);
			component.clip = _getObjectManager.GetInfoObject<AudioClip>(resourcesPathAudioClip);
			return component;
		}

		private void Initialize()
		{
			_audioMixer.SetFloat("GeneralVolume", _generalVolume = PlayerPrefs.GetFloat("GeneralVolume", 0));
			_audioMixer.SetFloat("MusicVolume", _musicVolume = PlayerPrefs.GetFloat("MusicVolume", -10));
			_audioMixer.SetFloat("EffectVolume", _effectVolume = PlayerPrefs.GetFloat("EffectVolume", -10));
		}
		public void SaveDataSubscription()
		{
			PlayerPrefs.SetFloat("GeneralVolume", _generalVolume);
			PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
			PlayerPrefs.SetFloat("EffectVolume", _effectVolume);
		}
	}
}