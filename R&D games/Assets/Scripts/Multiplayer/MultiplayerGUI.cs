using UnityEngine;
using System.Collections;

public class MultiplayerGUI : MonoBehaviour {
	
	public Texture crosshairTexture;

	private bool MenuEnabled = false;

	[RPC]
	private void Disconnect(){
		Network.Disconnect();
		Application.LoadLevel ("menu");
	}

	void OnGUI(){
		GUI.DrawTextureWithTexCoords(new Rect(Screen.width*.48f
		                         ,Screen.height*.48f
		                         ,Screen.width*.4f
		                         ,Screen.height*.4f), crosshairTexture,
		                             new Rect(0,0,1,1));
		if (MenuEnabled) {
			
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.1f), "Continue")) {
				MenuEnabled = false;
			}
			
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.375f, Screen.width * 0.5f, Screen.height * 0.1f), "Quit to menu")) {
				if(Network.isServer){
					MasterServer.UnregisterHost();
				}
				if(Network.isClient)
				{
					MasterServer.ClearHostList();
				}
				networkView.RPC ("Disconnect", RPCMode.All);
			}
			
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), "Exit game")) {
				Application.Quit ();
			}
		}
	}

	void Start(){
		if(!Network.isServer){
			camera.enabled = false;
		}
	}
	
	private void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
            MenuEnabled = !MenuEnabled;
        }
        
    }
}