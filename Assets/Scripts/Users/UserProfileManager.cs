using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;

/// <summary>
/// 	 Class that handles instantiating User Profile data from the SD card 
/// 	 or default initialisation for the first time users.
/// </summary>
public class UserProfileManager : MonoBehaviour 
{

	private 			FileManager 	_fileManager;				// Reference to the File Manager script which reads and saves the User Profile file to the SD card.

	public static event System.Action 	OnUserProfileSavedEvent;	// Raise an event when the User Profile JSON has been deserialised to the UserProfileData class.	


	// Use this for initialization
	void Start () 
	{
		_fileManager       = GameObject.Find(GameObjectsNameConstants.FILE_MANAGER).GetComponent<FileManager>();

		// Read the user profile data file from SD card, if not found, ...
		if(!_fileManager.readUserProfileDataFromSDCard())	
		{
			// Creates a new file with default User profile..... if file is not present. For FTUE or User who have deleted their user profile from SD card (in Android)
			_fileManager.saveUserProfileDataToSDCard();		
		}
		if(OnUserProfileSavedEvent != null)
			OnUserProfileSavedEvent();
	}


	void OnApplicationPause(bool paused)
	{
		// Save the user profile to the SD card whenever application is paused to keep the backup of current user progress..
		if(paused)
		{
			_fileManager.saveUserProfileDataToSDCard();
		}
	}


	void OnApplicationQuit()
	{
		// Save the user profile to the SD card whenever application is quitting...
		_fileManager.saveUserProfileDataToSDCard();
	}

}
