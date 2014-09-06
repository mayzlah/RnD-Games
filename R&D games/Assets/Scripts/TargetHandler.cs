using UnityEngine;
using System.Collections;

public class TargetHandeler : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.gameObject.name == "Projectile") {
						Destroy (gameObject);
				}
	}
}
