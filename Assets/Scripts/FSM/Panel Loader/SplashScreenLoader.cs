using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 	Enables the Splash Screen Panel in the UI Gameobject....
/// </summary>
public class SplashScreenLoader : StateBase 
{
	public GameObject splashPanel;

	protected override void Init()
	{
		base.Init();
		splashPanel.SetActive (true);
	}

	protected override void DeInit()
	{
		base.DeInit();
		splashPanel.SetActive (false);
	}

}
