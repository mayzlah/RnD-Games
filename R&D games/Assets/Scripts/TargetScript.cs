using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
	
	// Use this for initialization
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.name == "newProjectile") {
						Destroy (gameObject);
				}
	}

	void Start()
	{

	}
}
