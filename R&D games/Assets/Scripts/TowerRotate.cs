using UnityEngine;
using System.Collections;

public class TowerRotate : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
				float angle = Input.GetAxis ("Mouse X");
				transform.Rotate (Vector3.up, 50f * angle * Time.deltaTime, Space.Self);
		}
	
	}

