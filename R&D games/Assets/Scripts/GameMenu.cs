using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {


	private bool GUIEnabled = false;

	private void Start(){

	}
	void OnGUI(){
		if (GUIEnabled) {

						if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.1f), "Continue")) {
								GUIEnabled = false;
						}

						if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.375f, Screen.width * 0.5f, Screen.height * 0.1f), "Quit to menu")) {
								Application.LoadLevel ("menu");
						}

						if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), "Exit game")) {
								Application.Quit ();
						}
				}
	}

	private void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GUIEnabled = !GUIEnabled;
		}
		if (GUIEnabled) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
