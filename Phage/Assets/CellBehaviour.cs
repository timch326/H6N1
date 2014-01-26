using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour {

	static public bool isInitialState = true;
	public GameObject Virus;
	public int VirusCount = 1;
	public float circularSpreadValue = 0.1f;
	public float virusExplosionSpeed = 1000;

	public float VirusAttachTimeLimit = 3; //seconds
	private float TimeElapsed = 0;
	private bool hasVirus = false;
	
	// Use this for initialization
	void Start () {
		//startGame ();
	}
	
	// Update is called once per frame
	void Update() {

		if (hasVirus) {
			TimeElapsed += Time.deltaTime;

			if (VirusAttachTimeLimit <= TimeElapsed) {
				uninfectCell();
				Debug.Log ("Hello Time Elapsed!", this);
				TimeElapsed = 0;
			}
		}
	}


	// Destroy overlapping cells 
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("I hit a: " + coll.gameObject.name);
		//Debug.Log ("Tag: " + coll.gameObject.transform.GetChild(0).transform.GetChild(1).tag);
		if (coll.gameObject.CompareTag ("Virus_Tail")) {
			Debug.Log ("Collision of virus on this cell!", coll.gameObject);
			// when this cell gets hit by a virus, both be destroied
			//Destroy (coll.gameObject);
			infectCell();
//			}
		}
	}

	void OnMouseDown() {
		if (hasVirus) {
			killCell ();
			Debug.Log ("RIP");
		} else {
			Debug.Log ("I'm Healthy!");
		}
	}

	void killCell() {
		Destroy (gameObject);

		// Reproduce viruses
		for (int i = 0; i < VirusCount; i++) {
				GameObject clone;//a clone of the virus
				Vector2 cellPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y);
	
				float angle = i * 360 / VirusCount;
				Vector2 virusPosition = cellPosition + circularSpreadValue * new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad),
	                                                                         Mathf.Sin (angle * Mathf.Deg2Rad));
				//GameObject virusCollider = coll.gameObject;
				//Vector2 virusColliderDirection = virusCollider.rigidbody2D.velocity;
	
				// make new clone and change its facing diunirection
				//Quaternion rotation = Quaternion.Euler(CloneRotationVector);
				clone = Instantiate (Virus, virusPosition, Quaternion.identity) as GameObject;
				virus_bounce newVirusObject = clone.GetComponent<virus_bounce> ();
		
				newVirusObject.GoInDirection (angle, virusExplosionSpeed);
			}
		}
		
	public void infectCell() {
		hasVirus = true;
		// Set the sprite from "healthy" to "infected"
	}

	public void uninfectCell() {
		hasVirus = false;
		// Set the sprite from "infected" to "healthy"

}
}