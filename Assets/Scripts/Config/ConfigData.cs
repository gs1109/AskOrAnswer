using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public List<QuestionData> question_categories = new List<QuestionData> ();
}

/// <summary>
/// 	Facebook share related data such as what should be the limit to show video ads, and what should be the reward that needs to be given for 
/// </summary>
[System.Serializable]
public class QuestionData
{
	public string 		category;
	public List<string> questions = new List<string> ();
}