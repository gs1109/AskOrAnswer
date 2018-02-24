using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameConstants
{
	public const string SERVER_TIME_URL 						= "http://staging.bigmouthsolutions.com/servertime";

	// File Names for the Config and UserProfile file that we save on SD card...
	public const string USERPROFILE_DATA_FILE					= "askoranswer012377626281.json";
	public const string GAMEPLAY_CONFIG_DATA_FILE				= "askoranswer012377626282.json";

	// Prefs key for sounds and music settings...S
	public const string PREFS_IS_MUSIC_ON_KEY 					= "isMusicON";
	public const string PREFS_IS_SOUND_ON_KEY 					= "isSoundON";
}
