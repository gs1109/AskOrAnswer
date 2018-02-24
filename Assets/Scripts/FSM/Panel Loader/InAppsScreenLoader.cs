using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 	Enables the Level Map Screen Panel in the UI Gameobject....
/// </summary>
public class InAppsScreenLoader : StateBase 
{
	public GameObject levelMapPanel;

	protected override void Init()
	{
		base.Init();
		levelMapPanel.SetActive (true);
//		BackButtonHandler.instance.previousScenes.Add (stateID);
	}

	protected override void DeInit()
	{
		base.DeInit();
		levelMapPanel.SetActive (false);
//		BackButtonHandler.instance.previousScenes.RemoveAt (BackButtonHandler.instance.previousScenes.Count-1);
	}
}
