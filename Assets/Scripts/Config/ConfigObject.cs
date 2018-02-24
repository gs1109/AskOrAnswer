using UnityEngine;
using System.Collections;
using Pathfinding.Serialization.JsonFx;

/// <summary>
///  	Class handling for some general game data which needs to be configurable from the server and 
/// 	should reflect in the game on-the-fly.
/// </summary>
public class ConfigObject : MonoBehaviour 
{
	private 			FileManager 		_fileManager;

	public static event System.Action 		onConfigDataLoadedEvent;	// Raise an event when the Config Data JSON has been deserialised to the ConfigData class.	


	// Use this for initialization
	void Start () 
	{
		_fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
	}


	/// <summary>
	/// 	Handles the game play data fetched read from the config file.  It needs to be deserialised or set to the ConfigObject.Instance.
	/// </summary>
	/// <param name="configData">Config data.</param>
	void HandleonGamePlayDataFetchedEvent (string configData)
	{
		// Set the Config Data instance with the json fetched from the server.
		ConfigData.Instance = JsonReader.Deserialize<ConfigData>(configData);

		if(onConfigDataLoadedEvent != null)
			onConfigDataLoadedEvent();
	}
}
