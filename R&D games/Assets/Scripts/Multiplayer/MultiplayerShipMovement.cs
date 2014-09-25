using UnityEngine;
using System.Collections;

public class MultiplayerShipMovement : MonoBehaviour
{

	void Update () {
			if(Network.isClient){
			float yaw = Input.GetAxis ("Yaw");
			float pitch = Input.GetAxis ("Pitch");
			float roll = Input.GetAxis ("Roll");
			float vshift = Input.GetAxis ("Vertical shift");
			float hshift = Input.GetAxis ("Horizontal shift");
			float inspeed = Input.GetAxis ("Speed");
			
			if (yaw != 0f || pitch != 0f || roll != 0f) {
				// rotation around Y = roll, around X = pitch, around Z = yaw
				// momentum.x = pitch; momentum.y = -roll; momentum.z = -yaw;
				
				
				Vector3 momentum = new Vector3 (2f*pitch, -roll, -2f*yaw);
				rigidbody.AddRelativeTorque (10f*momentum * Time.deltaTime, ForceMode.Impulse);
			} else {
				rigidbody.angularDrag = 10;
			}
			if (vshift != 0f || hshift != 0f || inspeed != 0f) {
				Vector3 acceleration = new Vector3 (vshift, 10f*inspeed, -hshift);
				rigidbody.AddRelativeForce(25f*acceleration*Time.deltaTime);
			}
		}
		
		
	}
}

