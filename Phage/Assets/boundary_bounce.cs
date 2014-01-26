using UnityEngine;
using System.Collections;

public class boundary_bounce : MonoBehaviour {

	public Vector2 bounceOrientation;
	public float bounceForceMagnitude = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		coll.gameObject.rigidbody2D.AddForce (bounceOrientation * bounceForceMagnitude);
	}
}
