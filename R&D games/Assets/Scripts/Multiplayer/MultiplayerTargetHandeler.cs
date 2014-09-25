using UnityEngine;
using System.Collections;

public class MultiplayerTargetHandeler : MonoBehaviour
{

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.name == "newProjectile") {
			Network.Destroy (gameObject);
		}
	}
}

