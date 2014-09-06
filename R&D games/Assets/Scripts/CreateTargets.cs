using UnityEngine;
using System.Collections;

public class CreateTargets : MonoBehaviour {

	public int number = 50;
	public float closest = 10f;
	public float farest = 50f;


	public Rigidbody Target;

	private float RandomSign ()
	{
		float a;
		a = Random.Range (0, 2);
		return a * 2f - 1f;
	}

	// Use this for initialization
	void Start () {
				
		Quaternion rotation = new Quaternion();
		Vector3 position;
		
				int i;
		
				for (i=0; i<number; i++) {
						position = new Vector3 (Random.Range (closest, farest) * RandomSign ()
			                       , Random.Range (closest, farest) * RandomSign ()
			                       , Random.Range (closest, farest) * RandomSign ());

						Rigidbody newTarget = (Rigidbody)Instantiate (Target, position, rotation);
				}

	}
	

}
