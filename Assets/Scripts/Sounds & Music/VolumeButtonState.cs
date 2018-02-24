using UnityEngine;
using System.Collections;

public class VolumeButtonState : MonoBehaviour 
{
	public GameObject volumeOffBtn, volumeOnBtn;

	// Use this for initialization
	void OnEnable ()
	{
		if(volumeOffBtn.name.Contains("Music"))
		{
			if(string.IsNullOrEmpty(PlayerPrefs.GetString(GameConstants.PREFS_IS_MUSIC_ON_KEY)) || PlayerPrefs.GetString(GameConstants.PREFS_IS_MUSIC_ON_KEY).Equals("true"))
			{
				volumeOnBtn.SetActive(true);
				volumeOffBtn.SetActive(false);
			}
			else
			{
				volumeOnBtn.SetActive(false);
				volumeOffBtn.SetActive(true);
			}
		}
		else
		{
			if(string.IsNullOrEmpty(PlayerPrefs.GetString(GameConstants.PREFS_IS_SOUND_ON_KEY)) || PlayerPrefs.GetString(GameConstants.PREFS_IS_SOUND_ON_KEY).Equals("true"))
			{
				volumeOnBtn.SetActive(true);
				volumeOffBtn.SetActive(false);
			}
			else
			{
				volumeOnBtn.SetActive(false);
				volumeOffBtn.SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
