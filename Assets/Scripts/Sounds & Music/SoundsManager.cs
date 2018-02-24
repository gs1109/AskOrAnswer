using UnityEngine;
using System.Collections;

public class SoundsManager : MonoBehaviour 
{
	
	AudioSource source;

	// Use this for initialization
	void Start () 
	{
		source = GetComponent<AudioSource>();
	}

	
	public void PlaySound()
	{
		if(string.IsNullOrEmpty(PlayerPrefs.GetString(GameConstants.PREFS_IS_SOUND_ON_KEY)) || PlayerPrefs.GetString(GameConstants.PREFS_IS_SOUND_ON_KEY).Equals("true"))
		{
			source.Play();
		}
	}


	public void ToggleSound()
	{
		if(string.IsNullOrEmpty(PlayerPrefs.GetString(GameConstants.PREFS_IS_SOUND_ON_KEY)) || PlayerPrefs.GetString(GameConstants.PREFS_IS_SOUND_ON_KEY).Equals("true"))
		{
			PlayerPrefs.SetString(GameConstants.PREFS_IS_SOUND_ON_KEY, "false");
		}
		else
		{
			PlayerPrefs.SetString(GameConstants.PREFS_IS_SOUND_ON_KEY, "true");
		}
	}


	public void ToggleMusic()
	{
		if(string.IsNullOrEmpty(PlayerPrefs.GetString(GameConstants.PREFS_IS_MUSIC_ON_KEY)) || PlayerPrefs.GetString(GameConstants.PREFS_IS_MUSIC_ON_KEY).Equals("true"))
		{
			PlayerPrefs.SetString(GameConstants.PREFS_IS_MUSIC_ON_KEY, "false");
			GameObject.Find("BGMusic").GetComponent<AudioSource>().Stop();
		}
		else
		{
			PlayerPrefs.SetString(GameConstants.PREFS_IS_MUSIC_ON_KEY, "true");
			GameObject.Find("BGMusic").GetComponent<AudioSource>().Play();
		}
	}
}
