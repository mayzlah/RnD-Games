using UnityEngine;
using System.Collections;

public class MultiplayerObstacleSpawn : MonoBehaviour {

	public int number = 500;
	public float closest = 10f;
	public float farest = 50f;
	public float maxSize = 20f;
	public float minSize = 0.5f;
	
	public Rigidbody Obstacle;
	
	// Use this for initialization
	private float RandomSign ()
	{
		float a;
		a = Random.Range (0, 2);
		return a * 2f - 1f;
	}
	void Start () {
		if(Network.isServer)
		{
			float size;
			Quaternion rotation;
			Vector3 position;
			
			int i;
			
			for (i=0; i<number; i++) {
				position = new Vector3(Random.Range (closest, farest)*RandomSign()
				                       ,Random.Range (closest, farest)*RandomSign()
				                       ,Random.Range (closest, farest)*RandomSign());
				rotation = Random.rotation;
				size = Random.Range( minSize, maxSize);
				Rigidbody newObstacle = (Rigidbody)Network.Instantiate (Obstacle, position, rotation, 0);
				newObstacle.transform.localScale *= size;
			}
		}
	}

}
