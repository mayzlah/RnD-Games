using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public float cooldown = 1f;
	public Rigidbody projectile;

	private float fireTime;

	void Start () {
				
		}
	void Fire () {
		Rigidbody newProjectile = (Rigidbody)Instantiate (projectile, transform.position, transform.rotation);
		newProjectile.name = "newProjectile";
		newProjectile.freezeRotation = true;
		newProjectile.AddForce (transform.forward*50f, ForceMode.VelocityChange);
		}
	void Cooldown() 
	{
		fireTime = Time.time + cooldown;
		}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire")) {
			if(fireTime <= Time.time)
			{
				Fire ();
				Cooldown();
			}
				}
	}

}



