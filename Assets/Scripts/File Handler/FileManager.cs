using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using Pathfinding.Serialization.JsonFx;


/// <summary>
///  	Class that handles file handling of User Profile data, Config File data... Both saving and reading data from file...
/// </summary>
public class FileManager : MonoBehaviour
{

	string password = "kajs234kjasasdf3234sdf234dlfjl";		// Password to open the encrypted file....as we are saving the User Profile on the SD card.
	
	void Awake()
	{
		password = password.Substring(6);					// Just for security as it becomes even more difficult for the hacker to decompile and decode it.
	}


#region FILE_HANDLER_FOR_GENERAL_CONFIG_DATA
	/// <summary>
	/// 	Reads the gameplay config data from Resources
	/// </summary>
	/// <returns><c>true</c>, if config data from Resources, was read <c>false</c> otherwise.</returns>
	public bool readConfigDataFromResources()
	{
		try
		{
			// If latest saved config data is not there....i.e. first launch in offline mode... or user deleted the file and playing in offline mode..
			TextAsset backupConfigFile = (TextAsset)Resources.Load("questions_list");
		
			// If such file exists on the SD card, then read the contents of the file
			string backupConfigDataFileContents = backupConfigFile.ToString();
			// Decrypt the encrypted data to get the original level data which was retrieved from the server
			ConfigData.Instance = JsonReader.Deserialize<ConfigData>(backupConfigDataFileContents);

			return true; // and handle at the return of the function, maybe redownload the file again.

		} catch(Exception e) {
			return false;
		}

	}
	
	/// <summary>
	/// 	Saves the level data fetched from the server to SD card.
	/// </summary>
	/// <param name="levelDataJson">Level data json fetched from the server.</param>
	public void saveConfigDataToSDCard()
	{
		// Deserialize the level data json fetched from server into leveldata list 
		// which can be used to serialized into the file through binary formatter.
		try
		{
			// Deserialize the user profile data from the User Profile data instance...
			string configDataJson = JsonWriter.Serialize(ConfigData.Instance);

			// Encrypt the data fetched from the server to save it in the file and will be later retrieved when launched again.
			string encryptedConfigData = EncryptData(configDataJson);
			
			// Write the encrypted string to the file...
			File.WriteAllText(Application.persistentDataPath + "/" + GameConstants.GAMEPLAY_CONFIG_DATA_FILE, encryptedConfigData);
		}
		catch(IOException e)
		{
			Debug.LogError(e.ToString());
		}
	}
#endregion


	
#region FILE_HANDLER_FOR_USERPROFILE_DATA
	/// <summary>
	/// 	Reads the user profile data from SD card.
	/// </summary>
	public bool readUserProfileDataFromSDCard()
	{
		try
		{
			if(File.Exists(Application.persistentDataPath + "/" + GameConstants.USERPROFILE_DATA_FILE)) //
			{
				// If such file exists on the SD card, then read the contents of the file
				string encryptedUserDataFileContents = File.ReadAllText(Application.persistentDataPath + "/" + GameConstants.USERPROFILE_DATA_FILE);
				// Decrypt the encrypted data to get the original user profile data which was retrieved from the server.
				string decryptedUserProfileData = DecryptData(encryptedUserDataFileContents);

				// Set the instance of User Profile data with the latest data saved into the file...
				UserProfileData.Instance = JsonReader.Deserialize<UserProfileData>(decryptedUserProfileData);

				// Returns true, since file was read from the SD card 
				return true;
			}
			else
			{
				// User Profile data file was not found 
				return false;
			}
		}
		catch(IOException e)
		{
			// Exception occurred while reading the file contents..
			Debug.LogError(e.ToString());
			return false;
		}

	}
	
	/// <summary>
	/// Saves the user profile data to SD card from the value of UserProfile class.
	/// </summary>
	public void saveUserProfileDataToSDCard()
	{
		try
		{
			// Deserialize the user profile data from the User Profile data instance...
			string userProfileData = JsonWriter.Serialize(UserProfileData.Instance);

			// Encrypt the data fetched from the server to save it in the file and will be later retrieved when launched again.
			string encryptedUserProfileData = EncryptData(userProfileData);

			// Write the encrypted string to the file...
			File.WriteAllText(Application.persistentDataPath + "/" + GameConstants.USERPROFILE_DATA_FILE, encryptedUserProfileData);

		}
		catch(IOException e)
		{
			// Exception occurred due to file write operation..
			Debug.LogError(e.ToString());
		}
	}
#endregion




	void OnApplicationQuit()
	{
		saveUserProfileDataToSDCard();
	}

	/// <summary>
	/// 	Method which handles encryption of data from the provided passsword and needs the same password to decrypt the data...
	/// </summary>
	/// <returns>The string data after encryption.</returns>
	/// <param name="text">Text that needs to be encrypted</param>
	public string EncryptData(string text)
	{
		CryptoAlgo crypto  = new CryptoAlgo();	// Instantiating cryptoAlgo to encrypt the data....
		string encryptedString = crypto.encrypto(text, password);
		return encryptedString;
	}

	/// <summary>
	/// 	Method which handles decryption of encrypted data from the provided passsword.
	/// </summary>
	/// <returns>The original data after decryption.</returns>
	/// <param name="text">Encrypted text that needs to be decrypted to original string.</param>
	public string DecryptData(string text)
	{
		CryptoAlgo crypto  = new CryptoAlgo();	// Instantiating cryptoAlgo to decrypt the data....
		string decryptedString = crypto.decrypto(text, password);
		return decryptedString;
	}
	
}
