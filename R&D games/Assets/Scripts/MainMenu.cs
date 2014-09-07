using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public float topShift = Screen.height*0.25f;
	public float leftShift = Screen.width*0.25f;
	public float buttonWidth = Screen.width*0.5f;
	public float buttonHeight = Screen.height*0.1f;
	public float buttonGap = Screen.height*0.125f;

	void OnGUI () {
	
		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.1f), "Start")) {
						Application.LoadLevel ("proto");
				}
		if (GUI.Button (new Rect (Screen.width*0.25f, Screen.height*0.375f, Screen.width*0.5f, Screen.height*0.1f), "Host")) {
			
		}
		if (GUI.Button (new Rect (Screen.width*0.25f, Screen.height*0.5f, Screen.width*0.5f, Screen.height*0.1f), "Connect")) {
			
		}
		if (GUI.Button (new Rect (Screen.width*0.25f, Screen.height*0.625f, Screen.width*0.5f, Screen.height*0.1f), "Exit")) {
			Application.Quit();
		}
	
	}
}

