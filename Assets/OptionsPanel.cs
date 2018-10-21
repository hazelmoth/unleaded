using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour {

	public Slider volumeSlider;
	public AudioSource audioSource;

	void Start () {
		volumeSlider.value = PlayerPrefsManager.GetMusicVolume();
		audioSource = GameObject.FindObjectOfType<AudioSource> ();
	}

	void Update () {
		audioSource.volume = volumeSlider.value;
	}

	public void ExitOptionsMenu ()
	{
		PlayerPrefsManager.SetMusicVolume (volumeSlider.value);
	}
}
