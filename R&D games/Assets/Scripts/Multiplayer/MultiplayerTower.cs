using UnityEngine;
using System.Collections;

public class MultiplayerTower : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Network.isServer){
			float angle = Input.GetAxis ("Mouse X");
			transform.Rotate (Vector3.up, 50f * angle * Time.deltaTime, Space.Self);
		}
	
	}
}
