using UnityEngine;
using System.Collections;


/// <summary>
/// 	Script that manages playing BG music by checking with the user settings saved in the preferences...
/// </summary>
public class BGMusicManager : MonoBehaviour
{
	public static BGMusicManager instance;

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}


	void Start()
	{
		instance = GetComponent<BGMusicManager> ();
			// Plays the music as the User has not disabled the music settings....
			PlayMusic();

	}


	/// <summary>
	/// 	Plays the music...
	/// </summary>
	public void PlayMusic()
	{
		if (string.IsNullOrEmpty (PlayerPrefs.GetString (GameConstants.PREFS_IS_MUSIC_ON_KEY)) || PlayerPrefs.GetString (GameConstants.PREFS_IS_MUSIC_ON_KEY).Equals ("true")) {
			GetComponent<AudioSource> ().Play ();
		} else {
			GetComponent<AudioSource> ().Pause ();
		}
	}
}
