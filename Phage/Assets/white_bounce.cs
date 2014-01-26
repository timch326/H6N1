using UnityEngine;
using System.Collections;

public class white_bounce : MonoBehaviour {


	// used for testing bounce

	public float  x_force = 0f;
	public float  y_force = 1000f;
	public float angle = -90;
	public float force = 1000;

	// Use this for initialization
	void Awake () {
		GoInDirection (angle, force);
		//rigidbody2D.velocity = new Vector2(x_force, y_force);
	}

	public void GoInDirection(float angleIn, float forceIn){
		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(0,0,angleIn));
		rigidbody2D.velocity = new Vector2 (Mathf.Cos (angleIn*Mathf.Deg2Rad), 
		                                    Mathf.Sin (angleIn*Mathf.Deg2Rad)) *forceIn;
	}

	void FixedUpdate() {

	}

	void OnMouseDown() {
		Debug.Log ("Clicked! Virus!", this.gameObject);
	}
}
