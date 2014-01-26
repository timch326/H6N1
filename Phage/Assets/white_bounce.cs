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
		//GoInDirection (angle, force);
		//rigidbody2D.velocity = new Vector2(x_force, y_force);
	}

	public void GoInDirection(float angleIn, float forceIn){
		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(0,0,angleIn));
		rigidbody2D.velocity = new Vector2 (Mathf.Cos (angleIn*Mathf.Deg2Rad), 
		                                    Mathf.Sin (angleIn*Mathf.Deg2Rad)) *forceIn;
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			//float angleIn = Quaternion.LookRotation(Input.mousePosition).eulerAngles.x;
			//Debug.Log ("Aiming at " + angleIn + " degrees.");
			//GoInDirection (angleIn, force);

			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			pos = Camera.main.ScreenToWorldPoint(pos);

			var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
			transform.rotation = q;
			transform.rigidbody2D.velocity = (transform.up * force);
			Debug.Log ("Aiming at " + transform.rigidbody2D.velocity);
		}
	}

	void OnMouseDown() {
		Debug.Log ("Clicked! Virus!", this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Cell") {
			
			CellBehaviour cellBehaviour = collision.gameObject.GetComponent<CellBehaviour>();
			
			if (cellBehaviour.isInfected()) {
				cellBehaviour.killCell(false);
			}
		}
		else if (collision.gameObject.tag == "Virus" || collision.gameObject.tag == "Virus_Tail")
		{
			Debug.Log ("Fading: " + collision.gameObject.tag);
			collision.transform.GetChild(0).gameObject.GetComponent<virus_behaviour>().virusFade();
		} else {
			Debug.Log ("Unknown Tag: " + collision.gameObject.tag);
		}
	}
}
