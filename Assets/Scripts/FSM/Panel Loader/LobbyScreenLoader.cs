using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 	Enables the Lobby Screen Panel in the UI Gameobject....
/// </summary>
public class LobbyScreenLoader : StateBase 
{
	public GameObject lobbyPanel;

	protected override void Init()
	{
		base.Init();
		lobbyPanel.SetActive (true);
	}

	protected override void DeInit()
	{
		base.DeInit();
		lobbyPanel.SetActive (false);
	}
}
