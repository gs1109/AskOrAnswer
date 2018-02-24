using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 	Enables the MainGame Play Screen Panel in the UI Gameobject....
/// </summary>
public class MainGamePlayScreenLoader : StateBase 
{
	public GameObject mainGamePlayPanel;

	protected override void Init()
	{
		base.Init();
		mainGamePlayPanel.SetActive (true);
//		BackButtonHandler.instance.previousScenes.Add (stateID);
	}

	protected override void DeInit()
	{
		base.DeInit();
		mainGamePlayPanel.SetActive (false);
		//		BackButtonHandler.instance.previousScenes.RemoveAt (BackButtonHandler.instance.previousScenes.Count-1);
	}
}
