using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///  A serializable class to serialize/deserialize to/from JSON data for maintaining user profile data
///  like userId, emailId, etc
/// </summary>
[System.Serializable]
public sealed class UserProfileData
{
	private static volatile UserProfileData _instance;
	private static object lockingObject = new Object();
	// Wanted to keep this singleton, but JSONFX wants a public constructor to deserialize json object to classes.
	// Using it as a hot fix, but never try to access the instance from here instead get it from the Instance
	// property which will ensure the instance is same for every call.  
	public UserProfileData() {}
	// Property to send the only instance of this class
	public static UserProfileData Instance
	{
		get 
		{
			if (_instance == null) 
			{
				lock (lockingObject) 
				{
					// Only a single thread should enter this critical section area.
					if (_instance == null) 
						_instance = new UserProfileData();
				}
			}
			return _instance;
		}
		
		set 
		{
			_instance = value;
		}
	}
	
	// #############################################  Values to serialize/deserialize into/from JSON  ###################################################

	public	string 										userId					= "";
	public	string 										userName				= "Guest_" + SystemInfo.deviceUniqueIdentifier;
	public 	string 										deviceID 				= SystemInfo.deviceUniqueIdentifier;			
	public  bool										isFirstLaunch			= true;
	public  string										OS						= SystemInfo.operatingSystem;					
	public  string										deviceType				= SystemInfo.deviceModel;		
	public 	List<InappData>								userPlayedLevelData 	= new List<InappData> ();				// Data for the Opponents.
	// ##################################################################################################################################################
}


/// <summary>
/// Class for the inApp items which needs to be collected while playing the Level -- Objective type.
/// <param name="itemID"> ID of the elements which correspond this item</param>
/// <param name="amount"> Total count of items to be collected.</pararm>
/// </summary>
[System.Serializable]
public class InappData
{
	int 		levelNum;				// Level Number.
	long 		score;					// Score that User made in this level
	int 		starsEarned;			// Stars that he earned


	public int LevelNum
	{
		get {
			return this.levelNum; 
		}
		set	{
			this.levelNum = value;
		}
	}

	public long Score
	{
		get {
			return this.score;  
		}
		set {
			if(value >= this.score)
				this.score = value; 
		}
	}
	public int StarsEarned
	{
		get { 
			return this.starsEarned; 
		}
		set {
			if(value > this.starsEarned)
				this.starsEarned = value; 
		}
	}
}