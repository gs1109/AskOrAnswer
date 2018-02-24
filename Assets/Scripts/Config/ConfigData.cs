using UnityEngine;
using System.Collections;

/// <summary>
/// 	Config data related to the general gameplay config file....
/// </summary>
[System.Serializable]
public class ConfigData
{
	private static volatile ConfigData _instance;
	private static object lockingObject = new UnityEngine.Object();
	// Wanted to keep this singleton, but JSONFX wants a public constructor to deserialize json object to classes.
	// Using it as a hot fix, but never try to access the instance from here instead get it from the Instance
	// property which will ensure the instance is same for every call.  
	public ConfigData() {}
	// Property to send the only instance of this class
	public static ConfigData Instance
	{
		get 
		{
			if (_instance == null) 
			{
				lock (lockingObject) 
				{
					// Only a single thread should enter this critical section area.
					if (_instance == null) 
						_instance = new ConfigData();
				}
			}
			return _instance;
		}
		
		set 
		{
			_instance = value;
		}
	}
	
	
	public InAppPurchase	inAppPurchase;							
//	public VideoAds			videoAds;
	public SocialMedia		socialMedia;
	public int 				defaultRajniPowerUpCount  	= 2;		// Number of Rajnikanth power ups users would be given at start...
	public int 				defaultSachinPowerUpCount  	= 2;		// Number of Sachin power ups users would be given at start...
	public int 				defaultSalmanPowerUpCount  	= 2;		// Number of Salman power ups users would be given at start...
	public string 			rateUsURL					= "";
}

/// <summary>
/// In app purchase related data, that needs to be given when user purchases specific items through in-app.
/// </summary>
[System.Serializable]
public class InAppPurchase
{
	public double		inAppNoAdsPrice				= 10;

	public int 			inAppRajniPowerUpReward		= 3;
	public double		inAppRajniPowerUpPrice		= 10;
	public int 			inAppSachinPowerUpReward	= 3;
	public double		inAppSachinPowerUpPrice		= 10;
	public int 			inAppSalmanPowerUpReward	= 3;
	public double		inAppSalmanPowerUpPrice		= 10;
	public int 			inAppExtraMovesReward		= 5;
	public double		inAppExtraMovesPrice		= 10;
	public int 			inAppExtraTimeReward		= 30;
	public double		inAppExtraTimePrice			= 10;

	public string 		appId = "110111005";
	public string 		appName = "JungleRumble";
	public string 		extra_moves_ID = "221d9657e4e14f04b7c46f004901f41b";
	public string 		extra_time_ID = "c0b502cb4a5f43e192359973a2ab4042";
	public string 		rajnikanth_powerup_ID = "367b615cd25b46f4bc4d4c59cc490228";
	public string 		sachin_powerup_ID = "982ca56ed0fa473d90722a3752b86798";
	public string 		salmankhan_powerup_ID = "adbb382b67634b4a92839fbc9befe3a1";


}

/// <summary>
/// 	Facebook share related data such as what should be the limit to show video ads, and what should be the reward that needs to be given for 
/// </summary>
[System.Serializable]
public class SocialMedia
{
	// Share data.....
	public string		fbShareURL 					= "";		
	public string 		fbShareLinkName 			= "";		
	public string 		fbShareLinkCaption			= "";		
	public string 		fbShareLinkDescription		= "";		
	public string 		fbSharePictureURL			= "";		// Number of power ups that will be rewarded to the user for watching the video.

	public string		twitterShareMsg				= "";
	public string 		tweetAppURL					= "";
	// Like data
	public string 		fBLikeURL					= "";
}
