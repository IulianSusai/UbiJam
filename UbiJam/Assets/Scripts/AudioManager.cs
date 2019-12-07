using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { private set; get; }

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	[SerializeField] private AudioSource bgMusic;
	[SerializeField] private AudioSource dieSound;
	[SerializeField] private AudioSource tapSound;
	[SerializeField] private AudioSource blackHoleSound;
	[SerializeField] private AudioSource ggSound;

	public void PlayGGSound() {
		if (!ggSound.isPlaying) {
			ggSound.Play();
		}
	}

	public void PlayDieSound() {

		if (!dieSound.isPlaying) {
			dieSound.Play();
		}

	}

	public void PlayTapSound() {
		if (!tapSound.isPlaying) {
			tapSound.Play();
		}
	}

	public void PlayBlackHoleSound() {
		if (!blackHoleSound.isPlaying) {
			blackHoleSound.Play();
		}
	}

	public void StopBlackHoleSound() {
		if (blackHoleSound.isPlaying) {
			blackHoleSound.Stop();
		}
	}
}
