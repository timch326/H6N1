using UnityEngine;
using System.Collections;

public class virus_bounce : MonoBehaviour {


	// used for testing bounce

	public float  x_force = 0f;
	public float  y_force = 1000f;


	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce( new Vector2(x_force, y_force));
		//rigidbody2D.velocity = new Vector2(x_force, y_force);
	}
	
	void FixedUpdate() {

	}
}
