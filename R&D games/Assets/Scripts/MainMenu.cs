using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private float topShift;
	private float leftShift;
	private float buttonWidth;
	private float buttonHeight;
	private float buttonGap;
	
	public string ipAddressMS = "88.198.178.232";
	public int portMS = 48151;
	public int port = 48151;
	public string gameTypeName = "maizlach_proto";
	public string serverName = "Maizlach server";

	private string serverResult;

	private bool isMainMenu = true;
	private bool isServerStart = false;
	private bool isServer = false;
	private bool isClientStart = false;
	private bool isClient = false;

	private HostData[] serverList;
	public int numberOfServers;

	[RPC]
	private void LoadMultipLayerLevel(){
		Application.LoadLevel("multiplayer");
	}

	public void StartServer(){
		Debug.Log(Network.InitializeServer(1, port, !Network.HavePublicAddress()));

	}

	void OnServerInitialized(){
		MasterServer.ipAddress = ipAddressMS;
		MasterServer.port = portMS;
		MasterServer.RegisterHost(gameTypeName,serverName);
	}

	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if(msEvent == MasterServerEvent.RegistrationSucceeded)
		{
			serverResult = "Uspekhi!";
		}
		else if(msEvent == MasterServerEvent.HostListReceived)
		{
			serverList = MasterServer.PollHostList();
			numberOfServers = serverList.Length;
			Debug.Log (msEvent);
		}
		else {
			Debug.Log (msEvent);
		}
	}
	private void GetServerList(){
		MasterServer.ipAddress = ipAddressMS;
		MasterServer.port = portMS;
		MasterServer.RequestHostList(gameTypeName);
	}


	
	private void MainMenuGUI () {
		if (GUI.Button (new Rect (Screen.width * 0.25f
		                          ,Screen.height * 0.25f
		                          ,Screen.width * 0.5f
		                          ,Screen.height * 0.1f), "Start")) {
			Application.LoadLevel ("proto");
		}
		if (GUI.Button (new Rect (Screen.width*0.25f
		                          ,Screen.height*0.375f
		                          ,Screen.width*0.5f
		                          ,Screen.height*0.1f), "Host")) {
			isMainMenu = false;
			isServerStart = true;
		}
		if (GUI.Button (new Rect (Screen.width*0.25f
		                          ,Screen.height*0.5f
		                          ,Screen.width*0.5f
		                          ,Screen.height*0.1f), "Connect")) {
			GetServerList();
			isMainMenu = false;
			isClientStart = true;
		}
		if (GUI.Button (new Rect (Screen.width*0.25f
		                          ,Screen.height*0.625f
		                          ,Screen.width*0.5f
		                          ,Screen.height*0.1f), "Exit")) {
			Application.Quit();
		}
	}

	private void ServerStartGUI(){
		GUI.Label(new Rect(Screen.width*.2f
		                   ,Screen.height*.2f
		                   ,Screen.width*.2f
		                   ,Screen.height*.2f), "Server Name");
		serverName = GUI.TextField(new Rect(Screen.width*.5f
		                                    ,Screen.height*.2f
		                       				,Screen.width*.2f
		                       				,Screen.height*.2f), serverName);
		if(GUI.Button(new Rect(Screen.width*.2f
		                       ,Screen.height*.5f
		                       ,Screen.width*.2f
		                       ,Screen.height*.2f), "Back")){
			isServerStart = false;
			isMainMenu = true;
		}
		if(GUI.Button(new Rect(Screen.width*.5f
		                       ,Screen.height*.5f
		                       ,Screen.width*.2f
		                       ,Screen.height*.2f), "Start")){
			isServerStart = false;
			isServer = true;
			serverResult = "Waiting...";
			StartServer();
		}
	}

	private void ServerGUI(){
		GUI.Label(new Rect(Screen.width*.2f
		                   ,Screen.height*.2f
		                   ,Screen.width*.2f
		                   ,Screen.height*.2f), serverResult);
		if(GUI.Button(new Rect(Screen.width*.2f
		                       ,Screen.height*.5f
		                       ,Screen.width*.2f
		                       ,Screen.height*.2f), "Back")){
			isServer = false;
			isServerStart = true;
			MasterServer.UnregisterHost();
			Network.Disconnect();
		}
		GUI.Label(new Rect(Screen.width*.6f
		                   ,Screen.height*.2f
		                   ,Screen.width*.2f
		                   ,Screen.height*.2f),  Network.connections.Length.ToString());
		if (Network.connections.Length==1)
		{
			if(GUI.Button(new Rect(Screen.width*.6f
			                       ,Screen.height*.6f
			                       ,Screen.width*.2f
			                       ,Screen.height*.2f),  "Play")){
				networkView.RPC("LoadMultipLayerLevel", RPCMode.All);
			}
		}
	}

	private void ClientStartGUI(){
		GUI.Label(new Rect(Screen.width*.2f
		                   ,Screen.height*.2f
		                   ,Screen.width*.2f
		                   ,Screen.height*.2f), "Server List");
		if(GUI.Button(new Rect(Screen.width*.2f
		                       ,Screen.height*.5f
		                       ,Screen.width*.2f
		                       ,Screen.height*.2f), "Back")){
			isClientStart = false;
			isMainMenu = true;
		}
		if(numberOfServers == 0)
		{
			GUI.Label(new Rect(Screen.width*.6f
			                   ,Screen.height*.2f
			                   ,Screen.width*.2f
			                   ,Screen.height*.2f), "No Servers Found");
		}
		else{
			int i;
			for(i=0;i<numberOfServers;i++)
			{
				if(GUI.Button(new Rect(Screen.width*.6f
			                   		,Screen.height*.2f
			                   		,Screen.width*.2f
			                   		,Screen.height*.2f), serverList[i].gameName)){
					Debug.Log (Network.Connect(serverList[i]));
					isClient = true;
					isClientStart = false;
				}
			}				
		}

	}

	private void ClientGUI(){
		if(GUI.Button(new Rect(Screen.width*.2f
		                       ,Screen.height*.5f
		                       ,Screen.width*.2f
		                       ,Screen.height*.2f), "Back")){
			isClientStart = true;
			isClient = false;
		}
	}


	void Start() {
		topShift = Screen.height*0.25f;
		leftShift = Screen.width*0.25f;
		buttonWidth = Screen.width*0.5f;
		buttonHeight = Screen.height*0.1f;
		buttonGap = Screen.height*0.125f;

	}
	void OnGUI () {
		if(isMainMenu)
		{
			MainMenuGUI();
		}
		if(isServerStart){
			ServerStartGUI();
		}
		if(isServer)
		{
			ServerGUI();
		}
		if(isClientStart)
		{
			ClientStartGUI();
		}
		if(isClient)
		{
			ClientGUI();
		}
	}
}

