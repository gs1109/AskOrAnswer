using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SupportMailComposer
{
	/// <summary>
	/// 	Sends out a support mail with predefined user's data.
	/// </summary>
	public static void sendSupportMail()
	{
		string subject  = "Support Mail";
		string body     =     ""
			+ "\nWe are sending your following data for better troubleshooting purpose :"   
			+ "\nUserId              : " + UserProfileData.Instance.userId
			+ "\nVersion             : " + Application.version
			+ "\nDeviceID            : " + UserProfileData.Instance.deviceID
			+ "\nOS                  : " + UserProfileData.Instance.OS
			+ "\n----------------------------------------------------------"
			+ "\nPlease write below this line"
			+ "\n----------------------------------------------------------\n";
		Application.OpenURL("mailto:support@playsimple.in?subject=" + subject +"&body=" + body);
	}

}
