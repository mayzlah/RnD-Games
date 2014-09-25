using UnityEngine;
using System.Collections;

public class MultiplayerProjectileHandler : MonoBehaviour
{

	public Vector3 origin;
	
	private float duration = 10f/Time.deltaTime;
	private float range = 100f;
	private float timer = 0;
	
	void OnCollisionEnter (Collision collision)
	{
		Network.Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ((timer > duration) || (Vector3.Distance (origin, transform.position) > range)) {
			Network.Destroy (gameObject);
		}
		timer++;
	}
}

