using UnityEngine;
using System.Collections;

public class MultiplayerIfGunner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(!Network.isServer){
			gameObject.SetActive(false);
		}
	}
}
