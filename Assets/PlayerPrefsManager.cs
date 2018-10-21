using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager {

	const string MUSIC_VOLUME = "music_volume";


	public static void SetMusicVolume (float input)
	{
		if (input >= 0 && input <= 1)
		{
			PlayerPrefs.SetFloat (MUSIC_VOLUME, input);
		}
		else
		{
			Debug.LogError ("Music volume out of range");
		}
	}

	public static float GetMusicVolume ()
	{
		return PlayerPrefs.GetFloat (MUSIC_VOLUME, 0.75f);
	}
}
