using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (openMainGamePlayScreen ());
	}


	IEnumerator openMainGamePlayScreen(){
		
		yield return new WaitForSeconds (2f);

		GameObject.Find (GameObjectsNameConstants.MAIN_FSM).GetComponent<FSM> ().ChangeState (FiniteStateList.InAppsScreenState);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
