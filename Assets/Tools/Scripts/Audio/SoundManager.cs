using UnityEngine;

namespace AudioSystem
{
	public class SoundManager
	{
		public static AudioSource PlaySfxSound(AudioClip clip, Vector3 position = default, float pitch = 1f)
		{
			var go = new GameObject($"Audio{clip.name}");
			go.transform.position = position;
			var aus = go.AddComponent<AudioSource>();
			aus.playOnAwake = false;
			aus.spatialBlend = 1;
			aus.pitch = pitch;
			aus.clip = clip;
			aus.Play();
			return aus;
		}
		
		public static AudioSource PlayUISound(AudioClip clip)
		{
			var go = new GameObject($"Audio{clip.name}");
			var aus = go.AddComponent<AudioSource>();
			aus.playOnAwake = false;
			aus.spatialBlend = 0;
			aus.clip = clip;
			aus.Play();
			return aus;
		}
	}
}