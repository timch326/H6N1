using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour {

	static public bool isInitialState = true;
	public GameObject Virus;
	public int VirusCount = 1;




	// Use this for initialization
	void Start () {
		//startGame ();
	}
	
	// Update is called once per frame
	void Update () {
	  //
	}

	public float circularSpreadValue = 0.1f;

	// Destroy overlapping cells 
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("Virus")) {
				Debug.Log ("Collision of virus on this cell!", coll.gameObject);
				// when this cell gets hit by a virus, both be destroied
				Destroy (gameObject);
				Destroy (coll.gameObject);

			for(int i = 0; i< VirusCount; i++){
				Debug.Log ("", coll.gameObject);
				GameObject clone;//a clone of the virus
				Vector2 cellPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y);

				float angle = Random.Range(0,359);
				Vector2 virusPosition = cellPosition + circularSpreadValue * new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad),
				                                                                         Mathf.Sin(angle*Mathf.Deg2Rad));
				GameObject virusCollider = coll.gameObject;
				Vector2 virusColliderDirection = virusCollider.rigidbody2D.velocity;

				// make new clone and change its facing direction
				//Quaternion rotation = Quaternion.Euler(CloneRotationVector);
				clone = Instantiate(Virus, virusPosition, Quaternion.identity) as GameObject;
				virus_bounce newVirusObject = clone.GetComponent<virus_bounce>();

				float currentVelocityMagnitude = virusCollider.rigidbody2D.velocity.magnitude;

				newVirusObject.GoInDirection(angle, currentVelocityMagnitude);
				// apply force on each clone
//				clone.rigidbody2D.velocity = newVelocity * currentVelocityMagnitude;
			}
		}
	}

}
