using UnityEngine;
using System.Collections;

public class MultiplayerIfPilot : MonoBehaviour {

	// Use this for initialization
	void Start(){
		if(!Network.isClient){
			gameObject.SetActive(false);
        }
    }
}
